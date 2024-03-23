using System.ComponentModel.DataAnnotations;

namespace UniforBackend.Domain.Models.DTOs
{
    public class PostItemDTO
    {
        [Required]
        public string Nome { get; set; } = null!;
        [Required]
        public string Descricao { get; set; } = null!;
        [Required]
        public decimal Preco { get; set; }
        [Required]
        public string Tamanho { get; set; } = null!;
        [Required]
        public string Cor { get; set; } = null!;
    }
}
