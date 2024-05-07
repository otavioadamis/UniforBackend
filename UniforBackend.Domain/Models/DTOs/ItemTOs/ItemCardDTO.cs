using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.DTOs.ImageTOs;

namespace UniforBackend.Domain.Models.DTOs.ItemTOs
{
    public class ItemCardDTO
    {
        public string Id { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public decimal Preco { get; set; }
        public string SubCategoria { get; set; } = null!;
        public bool AceitaTroca { get; set; }
        public DateOnly PostadoEm { get; set; }
        public ImagemDTO ImagemPrincipal { get; set; } = null!;
    }
}