using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Exceptions;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.ImageTOs;

namespace UniforBackend.Service
{
    public class ImagemService : IImagemService
    {
        private readonly IImagemRepo _imagemRepo;
        private readonly IStorageService _storageService;

        public ImagemService(IImagemRepo imagemRepo, IStorageService storageService)
        {
            _imagemRepo = imagemRepo;
            _storageService = storageService;
        }

        public IEnumerable<ImagemDTO> GetAllImagesFromItem(string itemId)
        {
            var allImages = _imagemRepo.GetAllByItemId(itemId);
            return allImages;
        }

        public async Task DeleteImageAsync(string imageId)
        {
            ImagemDTO imagem = _imagemRepo.GetById(imageId);
            if(imagem == null)
            {
                throw new CustomException(new ErrorResponse
                {
                    Message = "Imagem não encontrada.",
                    StatusCode = (int)HttpStatusCode.NotFound,
                });
            }
            string key = imagem.URL.Split("/").Last();
            var response = await _storageService.DeleteFileAsync(key);
            if(response.StatusCode != 204)
            {
                throw new CustomException(new ErrorResponse
                {
                    Message = "Erro ao deletar imagem do bucket",
                    StatusCode = (int)HttpStatusCode.BadRequest
                });
            }
            _imagemRepo.Delete(imagem.Id);
            _imagemRepo.SaveChanges();
        }
    }
}
