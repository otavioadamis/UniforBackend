using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.DTOs.ImageTOs;

namespace UniforBackend.Domain.Interfaces.IServices
{
    public interface IImagemService
    {
        public IEnumerable<ImagemDTO> GetAllImagesFromItem(string itemId);
        public Task DeleteImageAsync(string imageId);
        public Task DeleteAllImagesOfItem(string itemId);
        public void ValidarImagens(List<IFormFile> imagens);
    }
}
