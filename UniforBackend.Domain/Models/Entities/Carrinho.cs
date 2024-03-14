using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.Entities
{
    public class Carrinho
    {
        [Key]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; } = null!;



        //EF Core mapping
        public User User { get; set; } = null!;
        
        [Column(TypeName = "varchar(36)")]
        public string UserId { get; set; } = null!;

        public ICollection<Item>? Itens { get; set; }
    }
}

