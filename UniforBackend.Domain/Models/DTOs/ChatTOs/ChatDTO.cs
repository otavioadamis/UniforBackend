using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.DTOs.ChatTOs
{
    public class ChatDTO
    {
        public string ChatName { get; set; } = null!;
        public string LastMessage { get; set; } = null!;
        
        //todo ChatImage (user image)
    }
}
