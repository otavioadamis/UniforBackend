using Microsoft.AspNetCore.Mvc;
using UniforBackend.API.Authorization;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.VendaTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {

        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpGet("{userId}")]
        public ActionResult<List<VendaDTO>> GetAllVendasFromUser(string userId)
        {
            var allVendas = _vendaService.GetAllVendasFromUser(userId);
            return Ok(allVendas);
        }

        [CustomAuthorize]
        [HttpPost("{itemId}")]
        public ActionResult<VendaDTO> RealizaVenda(string itemId)
        {
            var userFromJwt = (User)HttpContext.Items["User"];
            var newVenda = _vendaService.RealizaVenda(itemId, userFromJwt.Id);
            return Ok(newVenda);
        }
    }
}
