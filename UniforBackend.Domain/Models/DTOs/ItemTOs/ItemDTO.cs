using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Models.DTOs.ItemTOs
{
    public class ItemDTO
    {
        public string Id { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public decimal Preco { get; set; }
        public byte[]? Foto { get; set; }
        public bool AceitaTroca { get; set; }
        public DateOnly PostadoEm { get; set; }

        public ItemDTO() { }

        public ItemDTO(Item item)
        {
            Id = item.Id;
            Nome = item.Nome;
            Descricao = item.Descricao;
            Preco = item.Preco;
            Foto = item.Foto;
            AceitaTroca = item.AceitaTroca;
            PostadoEm = item.PostadoEm;
        }
    }
}
