using UniforBackend.Domain.Models.DTOs.ChatTOs;
using UniforBackend.Domain.Models.DTOs.PageTOs;

namespace UniforBackend.Domain.Interfaces.IServices
{
    public interface IChatService
    {
        public ChatDTO CreateChat(string currentUserId, string userId);
        public IEnumerable<ChatDTO> GetRecentChats(string userId);
        public PagedResult<MensagemDTO> GetMessagesFromChat(string chatId, int index, string userId);
        public Task<MensagemSocketDTO> SaveMessageAsync(SendMensagemDTO mensagem);
    }
}
