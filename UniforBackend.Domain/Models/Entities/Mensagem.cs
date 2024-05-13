using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.Entities
{
    public class Mensagem
    {
        [Key]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; } = null!;

        [Column(TypeName = "varchar(60)")]
        public string Sender { get; set; } = null!;

        [Column(TypeName = "varchar(500)")]
        public string Content { get; set; } = null!;

        //EF Core mapping
        public Chat Chat { get; set; } = null!;
        public string ChatId { get; set; } = null!;
        public DateTime SendedAt { get; set; }
    }
}
