using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.DTOs.S3TOs;

namespace UniforBackend.Domain.Interfaces.IServices
{
    public interface IStorageService
    {
        public Task<S3ResponseDTO> UploadFileAsync(IFormFile image, string nome, string fileExt, int index);
        public Task<S3ResponseDTO> UpdateFileAsync(IFormFile image, string key);
        public Task<S3ResponseDTO> DeleteFileAsync(string key);
    }
}
