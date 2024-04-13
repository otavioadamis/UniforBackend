using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniforBackend.Domain.Models.Entities
{
    public class Categoria
    {
        [Key]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; } = null!;

        [Column(TypeName = "varchar(60)")]
        public string Nome { get; set; } = null!;


        //EF Core mapping
        public ICollection<SubCategoria> SubCategorias { get; set; } = null!;
    }
}
