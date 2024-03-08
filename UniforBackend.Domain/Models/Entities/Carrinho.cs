using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.Entities
{
    public class Carrinho
    {
        [Key]
        public string Id { get; set; } = null!;

        // n/n com itens
        // 1/1 com user 
    }
}
