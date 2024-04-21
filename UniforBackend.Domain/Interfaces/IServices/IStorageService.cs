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
        Task<S3ResponseDTO> UploadFileAsync(IFormFile image, string nome);
    }
}
