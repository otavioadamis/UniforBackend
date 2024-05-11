using Microsoft.AspNetCore.Mvc;
using UniforBackend.API.Authorization;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.ImageTOs;
using UniforBackend.Domain.Models.DTOs.S3TOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagemController : ControllerBase
    {
        private readonly IImagemService _imagemService;
        public ImagemController(IImagemService imagemService)
        {
            _imagemService = imagemService;
        }

        [HttpGet("{itemId}")]
        public ActionResult<ImagemDTO> Get(string itemId) 
        {
            var allImages = _imagemService.GetAllImagesFromItem(itemId);
            return Ok(allImages);
        }

        [CustomAuthorize]
        [HttpPut("{itemId}/{index}")]
        public async Task<ActionResult<UpdateImagemDTO>> Update(string itemId, int index, IFormFile imagem)
        {
            var userFromJwt = (User)HttpContext.Items["User"];
            var response = await _imagemService.UpdateImageAsync(itemId, index, imagem, userFromJwt.Id);
            return Ok(response);
        }

        [CustomAuthorize]
        [HttpDelete("{imageId}")]
        public async Task<ActionResult<S3ResponseDTO>> Delete(string imageId)
        {
            await _imagemService.DeleteImageAsync(imageId);
            return Ok("Imagem deletada.");
        }
    }
}
