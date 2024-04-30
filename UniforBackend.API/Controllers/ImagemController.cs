using Microsoft.AspNetCore.Mvc;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Models.DTOs.ImageTOs;

namespace UniforBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagemController : ControllerBase
    {
        private readonly IImagemRepo _imagemRepo;

        public ImagemController(IImagemRepo imagemRepo)
        {
            _imagemRepo = imagemRepo;
        }

        [HttpGet("{itemId}")]
        public ActionResult<ImagemDTO> Get(string itemId) 
        {
            var allImages = _imagemRepo.GetAllByItemId(itemId);
            return Ok(allImages);
        }
    }
}
