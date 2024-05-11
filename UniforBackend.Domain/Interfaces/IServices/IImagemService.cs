using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UniforBackend.Domain.Models.DTOs.ImageTOs;

namespace UniforBackend.Domain.Interfaces.IServices
{
    public interface IImagemService
    {
        public IEnumerable<ImagemDTO> GetAllImagesFromItem(string itemId);
        public Task<UpdateImagemDTO> UpdateImageAsync(string itemId, int index, IFormFile novaImagem, string anuncianteId);
        public Task DeleteImageAsync(string imageId);
    }
}
