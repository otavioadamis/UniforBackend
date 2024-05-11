using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Models.DTOs.ImageTOs
{
    public class UpdateImagemDTO
    {
        public string Id { get; set; } = null!;
        public string URL { get; set; } = null!;
        public string Extensao { get; set; }

        public UpdateImagemDTO()
        {
        }

        public UpdateImagemDTO(Imagem imagem)
        {
            Id = imagem.Id;
            URL = $"https://uniforbackend-test.s3.amazonaws.com/{imagem.ItemId}_{imagem.Index}{imagem.Extensao}";
            Extensao = imagem.Extensao;
        }
    }
}
