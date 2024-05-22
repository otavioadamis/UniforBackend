namespace UniforBackend.Domain.Models.DTOs.ChatTOs
{
    public class MensagemSocketDTO
    {
        public string Content { get; set; } = null!;
        public string ToChatId { get; set; } = null!;
        public string SenderId { get; set; } = null!;
        public string SenderName { get; set; } = null!;
        public DateTime SendedAt { get; set; }
    }
}
