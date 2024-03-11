using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.Entities
{
    public class CompraItem
    {
        public string Id { get; set; } = null!;

        public string ItemId { get; set; } = null!;
        public Item Item { get; set; } = null!;

        public string CompraId { get; set; } = null!;
        public Compra Compra { get; set; } = null!;
    }
}
