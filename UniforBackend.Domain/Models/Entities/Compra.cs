using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniforBackend.Domain.Models.Entities
{
    public class Compra
    {
        [Key]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; } = null!;
        public required DateTime DataCompra { get; set; }

     
        //EF Core mapping
        public User Comprador { get; set; } = null!;

        [Column(TypeName = "varchar(36)")]
        public string CompradorId { get; set; } = null!;

        public User Vendedor { get; set; } = null!;

        [Column(TypeName = "varchar(36)")]
        public string VendedorId { get; set; } = null!;

        public Item Item { get; set; } = null!;
        
        [Column(TypeName = "varchar(36)")]
        public string ItemId { get; set; } = null!;
    }
}
