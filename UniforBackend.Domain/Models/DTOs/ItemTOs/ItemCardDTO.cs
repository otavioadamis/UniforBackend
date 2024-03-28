using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.DTOs.ItemTOs
{
    public class ItemCardDTO
    {
        public string Id { get; set; } = null!;
        public required string Nome { get; set; }
        public required decimal Preco { get; set; }
    }
}

//TODO -> Adicionar imagens futuramente (card)