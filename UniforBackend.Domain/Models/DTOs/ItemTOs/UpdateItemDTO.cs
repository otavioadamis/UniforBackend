using Microsoft.AspNetCore.Http;
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
        public string Nome { get; set; } = null!;
        [Required]
        public string Descricao { get; set; } = null!;
        [Required]
        public decimal Preco { get; set; }
        [Required]
        public bool AceitaTroca { get; set; }
        [Required]
        public bool MostrarContato { get; set; }

        public void UpdateFields(Item item)
        {
            item.Nome = Nome;
            item.Descricao = Descricao;
            item.Preco = Preco;
            item.AceitaTroca = AceitaTroca;
            item.MostrarContato = MostrarContato;
        }

    }
}
