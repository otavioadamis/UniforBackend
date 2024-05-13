namespace UniforBackend.Domain.Models.DTOs.ChatTOs
{
    public class MensagemDTO
    {
        public string Content { get; set; } = null!;
        public string SenderName { get; set; } = null!;
        public DateTime SendedAt { get; set; }
    }
}
