using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.Entities
{
    public class Item
    {
        [Key]
        public string Id { get; set; } = null!;
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public required decimal Preco { get; set; }
        public required int quantidade { get; set; }
        public required string Tamanho {  get; set; }
        public required string Cor { get; set; }
        // n/1 com user
    }
}
