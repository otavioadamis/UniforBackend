using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniforBackend.Domain.Models.Entities
{
    public class Venda
    {
        [Key]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; } = null!;
        public required DateTime DataVenda { get; set; }

        //EF Core mapping
        public User Vendedor { get; set; } = null!;

        [Column(TypeName = "varchar(36)")]
        public string VendedorId { get; set; } = null!;

        public Item Item { get; set; } = null!;
        
        [Column(TypeName = "varchar(36)")]
        public string ItemId { get; set; } = null!;
    }
}
