using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.Entities
{
    public class CarrinhoItem
    {
        public string Id { get; set; } = null!;

        public string CarrinhoId { get; set; } = null!;
        public Carrinho Carrinho { get; set; } = null!;

        public string ItemId { get; set; } = null!;
        public Item Item { get; set; } = null!;
    }
}
