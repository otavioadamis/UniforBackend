using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.Entities;
using UniforBackend.Domain.Models.DTOs.ImageTOs;

namespace UniforBackend.Domain.Models.DTOs.ItemTOs
{
    public class ItemDTO
    {
        public string Id { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public decimal Preco { get; set; }
        public string? Foto { get; set; }
        public bool AceitaTroca { get; set; }
        public bool MostrarContato { get; set; }
        public string VendedorId { get; set; } = null!;
        public string NomeVendedor { get; set; } = null!;
        public string ContatoVendedor { get; set; } = null!;
        public string SubCategoria { get; set; } = null!;
        public DateOnly PostadoEm { get; set; }
        public ImagemDTO[] Imagens { get; set; } = null!;
    }
}
