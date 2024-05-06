using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.DTOs.ChatTOs
{
    public class SendMensagemDTO
    {
        public string ToChatId { get; set; } = null!;
        public string FromUserId { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
