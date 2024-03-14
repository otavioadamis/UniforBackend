using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.Entities
{
    public class CarrinhoItem
    {
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; } = null!;

        [Column(TypeName = "varchar(36)")]
        public string CarrinhoId { get; set; } = null!;
        public Carrinho Carrinho { get; set; } = null!;

        [Column(TypeName = "varchar(36)")]
        public string ItemId { get; set; } = null!;
        public Item Item { get; set; } = null!;
    }
}
