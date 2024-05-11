using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using UniforBackend.Domain.Exceptions;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.ImageTOs;
using UniforBackend.Domain.Models.DTOs.S3TOs;

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

        public async Task<UpdateImagemDTO> UpdateImageAsync(string imageId, IFormFile imagem)
        {
            ImagemDTO _imagem = _imagemRepo.GetById(imageId);
            if(_imagem == null)
            {
                throw new CustomException(new ErrorResponse
                {
                    Message = "Imagem não encontrada.",
                    StatusCode = (int)HttpStatusCode.NotFound,
                });
            }
            string key = _imagem.URL.Split("/").Last(); // solução temporária, ajustar o DTO para conter essa informação
            S3ResponseDTO s3res = await _storageService.UpdateFileAsync(imagem, key);
            if(s3res.StatusCode != 200)
            {
                throw new CustomException(new ErrorResponse
                {
                    Message = "Erro ao atualizar imagem no bucket",
                    StatusCode = (int)HttpStatusCode.BadRequest
                });
            }
            string ext = Path.GetExtension(imagem.FileName);
            var response = new UpdateImagemDTO(
                _imagemRepo.UpdateExtensao(imageId, ext)
            );
            return response;
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
            string key = imagem.URL.Split("/").Last(); // solução temporária, ajustar o DTO para conter essa informação
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
