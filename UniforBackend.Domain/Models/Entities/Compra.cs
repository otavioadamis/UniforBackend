using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.enums;

namespace UniforBackend.Domain.Models.Entities
{
    public class Compra
    {
        [Key]
        public string Id { get; set; } = null!;
        public required string DataCompra { get; set; }
        public required Status Status { get; set; }
        public required MetodoPagamento MetodoPagamento { get; set; }


        // Mapeacao EntityFramework
        // n pra 1 com users
        public User User { get; set; } = null!;
        public string UserId { get; set; } = null!;

        // n/n com itens
        public ICollection<Item> Itens { get; set; } = null!;
    }
}
