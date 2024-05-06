using System.Net;
using UniforBackend.Domain.Exceptions;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.ChatTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Service
{
    public class ChatService : IChatService
    {
        private readonly IUserRepo _userRepo;
        private readonly IChatRepo _chatRepo;
        private readonly IMensagemRepo _mensagemRepo;

        public ChatService(IUserRepo userRepo, IChatRepo chatRepo, IMensagemRepo mensagemRepo)
        {
            _userRepo = userRepo;
            _chatRepo = chatRepo;
            _mensagemRepo = mensagemRepo;
        }

        public ChatDTO CreateChat(string senderUserId, string receiverId)
        {
            var chatUser = _userRepo.GetById(receiverId);
            var currentUser = _userRepo.GetById(senderUserId);

            if (currentUser == null || chatUser == null)
            {
                throw new CustomException(new ErrorResponse
                {
                    Message = "Erro ao criar chat",
                    StatusCode = (int)HttpStatusCode.NotFound
                });
            }

            var existingChat = _chatRepo.GetDTOByUsers(senderUserId, receiverId);
            if (existingChat != null)
            {
                return existingChat;
            }

            var newChat = new Chat()
            {
                Users = new List<User>() { currentUser, chatUser },
            };

            _chatRepo.Add(newChat);
            _chatRepo.SaveChanges();

            var newChatDTO = new ChatDTO()
            {
                Id = newChat.Id,
                ChatName = chatUser.Nome,
            };
            return newChatDTO;
        }

        public IEnumerable<ChatDTO> GetRecentChats(string userId)
        {
            var recentChats = _chatRepo.GetRecentChatsFromUserId(userId);
            return recentChats;
        }

        public IEnumerable<MensagemDTO> GetMessagesFromChat(string chatId)
        {
            var allMessages = _mensagemRepo.GetMessagesFromChatId(chatId);
            return allMessages;
        }

        public async Task SaveMessageAsync(string toChatId, string message, string senderId)
        {
            var senderUser = _userRepo.GetById(senderId);

            var newMessage = new Mensagem()
            {
                ChatId = toChatId,
                Content = message,
                Sender = senderId,
                SendedAt = DateTime.UtcNow, //todo -> deixar o banco fazer isso
            };

            _mensagemRepo.Add(newMessage);
            _mensagemRepo.SaveChanges();

            var chat = _chatRepo.GetById(toChatId);
            chat.UpdatedAt = newMessage.SendedAt;
            _chatRepo.SaveChanges();
        }
    }
}
