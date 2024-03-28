using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Models.DTOs.ItemTOs
{
    public class UpdateItemDTO
    {
        [Required]
        public string NovoNome { get; set; } = null!;
        [Required]
        public string NovaDescricao { get; set; } = null!;
        [Required]
        public decimal NovoPreco { get; set; }

        public void UpdateFields(Item item)
        {
            item.Nome = NovoNome;
            item.Descricao = NovaDescricao;
            item.Preco = NovoPreco;
        }

    }
}
