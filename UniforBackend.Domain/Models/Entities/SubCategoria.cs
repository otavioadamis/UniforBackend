using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.Entities
{
    public class SubCategoria
    {
        [Key]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; } = null!;

        [Column(TypeName = "varchar(60)")]
        public string Nome { get; set; } = null!;

        // EF Core mapping
        public Categoria Categoria { get; set; } = null!;
        public string CategoriaId { get; set; } = null!;

        public ICollection<Item>? Items { get; set; }
    }
}
