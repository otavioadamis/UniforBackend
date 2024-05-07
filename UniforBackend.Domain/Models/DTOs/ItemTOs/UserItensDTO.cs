using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.DTOs.PageTOs;

namespace UniforBackend.Domain.Models.DTOs.ItemTOs
{
    public class UserItensDTO
    {
        public string UserId { get; set; } = null!;
        public string Nome {  get; set; } = null!;
        public IEnumerable<ItemCardDTO>? Itens { get; set; }
    }
}
