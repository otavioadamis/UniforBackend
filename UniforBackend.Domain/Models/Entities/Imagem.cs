using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.Entities
{
    public class Imagem
    {
        [Key]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; } = null!;
        
        [Column(TypeName = "varchar(10)")]
        public string Extensao { get; set; } = null!;
        public int Index { get; set; }

        //EF Core mapping
        public Item Item { get; set; } = null!;
        public string ItemId { get; set; } = null!;

    }
}
