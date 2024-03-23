using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs;

namespace UniforBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("{pagina}")]
        public ActionResult<ListItemCardResponse> GetItensFromPagina(int pagina) 
        {
            if(pagina < 1) { pagina = 1; }
            
            var itens = _itemService.GetAllItens(pagina);
            return Ok(itens);
        }

        [HttpGet("user/{userId}")]
        public ActionResult<ItemCardDTO> GetItensFromUserId(string userId)
        {
            var itens = _itemService.GetItensFromUserId(userId);
            return Ok(itens);
        }

        // TODO - > o ideal era pegar o userid pelo proprio token de autorização,
        // e não temos menor ideia de como vai ser autorização ainda nesse projeto.
        
        [HttpPost()]
        public ActionResult<ItemCardDTO> AddItem(PostItemDTO item, string userId)
        {
            var addedItem = _itemService.AddItem(item, userId);
            return Ok(addedItem);
        }

        //Delete Item

        //Update Item
    }
}
