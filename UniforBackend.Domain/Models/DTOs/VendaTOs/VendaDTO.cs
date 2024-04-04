using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.DTOs.VendaTOs
{
    public class VendaDTO
    {
        public string Id { get; set; } = null!;
        public string NomeItem { get; set; } = null!;
        public DateTime DataVenda { get; set; }
        public decimal preco { get; set; }
    }
}
