using Microsoft.AspNetCore.Mvc;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.ImageTOs;
using UniforBackend.Domain.Models.DTOs.S3TOs;
using UniforBackend.Service;

namespace UniforBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagemController : ControllerBase
    {
        private readonly IImagemRepo _imagemRepo;
        private readonly IStorageService _storageService;

        public ImagemController(IImagemRepo imagemRepo, IStorageService storageService)
        {
            _imagemRepo = imagemRepo;
            _storageService = storageService;
        }

        [HttpGet("{itemId}")]
        public ActionResult<ImagemDTO> Get(string itemId) 
        {
            var allImages = _imagemRepo.GetAllByItemId(itemId);
            return Ok(allImages);
        }

        // delete image
        [HttpDelete("{imageId}")]
        public async Task<ActionResult<S3ResponseDTO>> Delete(string imageId)
        {
            var res = await _storageService.DeleteFileAsync(imageId);
            return Ok(res);
        }
    }
}
