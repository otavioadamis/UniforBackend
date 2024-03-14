using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.enums;

namespace UniforBackend.Domain.Models.Entities
{
    public class Compra
    {
        [Key]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; } = null!;
        public required DateTime DataCompra { get; set; }
        public required Status Status { get; set; }
        public required MetodoPagamento MetodoPagamento { get; set; }


        
        //EF Core mapping
        public User Comprador { get; set; } = null!;

        [Column(TypeName = "varchar(36)")]
        public string CompradorId { get; set; } = null!;

        public User Vendedor { get; set; } = null!;

        [Column(TypeName = "varchar(36)")]
        public string VendedorId { get; set; } = null!;

        public ICollection<Item> Itens { get; set; } = null!;
    }
}
