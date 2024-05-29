using Microsoft.AspNetCore.Http;
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
using UniforBackend.Domain.Models.Entities;
using static System.Net.Mime.MediaTypeNames;

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

        public async Task DeleteAllImagesOfItem(string itemId)
        {
            var allImages = _imagemRepo.GetAllByItemId(itemId);
            foreach(ImagemDTO imagem in allImages)
            {
                string key = imagem.URL.Split("/").Last();
                await _storageService.DeleteFileAsync(key);
            }
        }

        public void ValidarImagens(List<IFormFile> imagens)
        {
            if (imagens.Count() > 3)
            {
                throw new CustomException(new ErrorResponse()
                {
                    Message = "Limite máximo de imagens ultrapassado, apenas 3 imagens!",
                    StatusCode = (int)HttpStatusCode.BadRequest,
                });
            }

            string[] permittedExtensions = { ".png", ".jpg", ".jpeg" };
            
            foreach(IFormFile imagem in imagens)
            {
                var ext = Path.GetExtension(imagem.FileName).ToLowerInvariant();
                
                if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                {
                    throw new CustomException(new ErrorResponse()
                    {
                        Message = "Extensão de imagem deve ser apenas png, jpg ou jpeg.",
                        StatusCode = (int)HttpStatusCode.BadRequest,
                    });
                }
            }
        }
    }
}
