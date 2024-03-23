using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.Entities
{
    public class Item
    {
        [Key]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; } = null!;

        [Column(TypeName = "varchar(60)")]
        public required string Nome { get; set; }

        [Column(TypeName = "varchar(255)")]
        public required string Descricao { get; set; }
        public required decimal Preco { get; set; }
        public required int Quantidade { get; set; }

        [Column(TypeName = "varchar(30)")]
        public required string Tamanho {  get; set; }

        [Column(TypeName = "varchar(30)")]
        public required string Cor { get; set; }

        public bool IsVendido { get; set; } = false;

        //EF Core mapping
        public User User { get; set; } = null!;
        public string UserId { get; set; } = null!;

    }
}

//TODO -> Adicionar imagens futuramente