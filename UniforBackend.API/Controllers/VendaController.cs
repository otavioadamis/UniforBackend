using Microsoft.AspNetCore.Mvc;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.VendaTOs;

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

        [HttpPost("{userId}/{itemId}")]
        public ActionResult<VendaDTO> RealizaVenda(string itemId, string userId)
        {
            var newVenda = _vendaService.RealizaVenda(itemId, userId);
            return Ok(newVenda);
        }
    }
}
