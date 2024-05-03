using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.Entities
{
    public class Chat
    {
        [Key]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; } = null!;

        [Column(TypeName = "varchar(60)")]
        public DateTime UpdatedAt { get; set; }

        //todo > chat image

        //EF Core mapping
        public Mensagem? LatestMessage { get; set; }
        public string? LatestMessageId { get; set; }
        public ICollection<User> Users { get; set; } = null!;
    }
}
