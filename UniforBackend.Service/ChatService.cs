using System.Net;
using UniforBackend.Domain.Exceptions;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.ChatTOs;
using UniforBackend.Domain.Models.DTOs.PageTOs;
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
                OtherUserId = chatUser.Id,
            };
            return newChatDTO;
        }

        public IEnumerable<ChatDTO> GetRecentChats(string userId)
        {
            var recentChats = _chatRepo.GetRecentChatsFromUserId(userId);
            return recentChats;
        }

        public PagedResult<MensagemDTO> GetMessagesFromChat(string chatId, int index, string userId)
        {
            var allMessages = _mensagemRepo.GetMessagesFromChatId(chatId, index); 
            
            var currentUserChat = _chatRepo.GetUserChatFromUserIdAndChatId(userId, chatId);
            currentUserChat.UnreadMessages = 0;
            _chatRepo.SaveChanges();
            
            return allMessages;
        }

        public async Task<MensagemSocketDTO> SaveMessageAsync(SendMensagemDTO mensagem)
        {
            var senderUser = _userRepo.GetById(mensagem.FromUserId);
            var chat = _chatRepo.GetById(mensagem.ToChatId);

            if (senderUser == null || chat == null)
            {
                throw new CustomException(new ErrorResponse
                {
                    Message = "Erro ao enviar mensagem",
                    StatusCode = (int)HttpStatusCode.NotFound,
                });
            }

            var newMessage = new Mensagem()
            {
                ChatId = chat.Id,
                Content = mensagem.Content,
                Sender = senderUser.Id,
                SendedAt = DateTime.UtcNow,
            };

            _mensagemRepo.Add(newMessage);
            _mensagemRepo.SaveChanges();

            chat.UpdatedAt = newMessage.SendedAt;
            chat.LatestMessageId = newMessage.Id;
            
            var otherUserChat = _chatRepo.GetUserChatFromUserIdAndChatId(mensagem.ToUserId, chat.Id);
            otherUserChat.UnreadMessages++;
            
            _chatRepo.SaveChanges();

            var mensagemDTO = new MensagemSocketDTO()
            {
                ToChatId = newMessage.ChatId,
                SenderId = newMessage.Sender,
                SenderName = senderUser.Nome,
                Content = newMessage.Content,
                SendedAt = newMessage.SendedAt,
            };
            return mensagemDTO;
        }
    }
}
