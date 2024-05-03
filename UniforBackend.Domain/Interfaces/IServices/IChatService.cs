using UniforBackend.Domain.Models.DTOs.ChatTOs;

namespace UniforBackend.Domain.Interfaces.IServices
{
    public interface IChatService
    {
        public ChatDTO CreateChat(string currentUserId, string userId);
        public IEnumerable<ChatDTO> GetRecentChats(string userId);
        public IEnumerable<MensagemDTO> GetMessagesFromChat(string chatId);
    }
}
