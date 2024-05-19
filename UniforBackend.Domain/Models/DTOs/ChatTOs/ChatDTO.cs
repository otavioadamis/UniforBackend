using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.DTOs.ChatTOs
{
    public class ChatDTO
    {
        public string Id { get; set; } = null!;
        public string ChatName { get; set; } = null!;
        public string OtherUserId { get; set; } = null!;
        public string LastMessage { get; set; } = null!;
        public int UnreadMessages { get; set; }
    }
}
