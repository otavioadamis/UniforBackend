using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniforBackend.API.Authorization;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.ItemTOs;
using UniforBackend.Domain.Models.Entities;

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
        public ActionResult<ListItemCardResponse> GetItensFromPagina(string? search, int pagina)
        {
            if (pagina < 1) { pagina = 1; }

            var itens = _itemService.GetAllItens(search, pagina);
            return Ok(itens);
        }

        [HttpGet("user/{userId}")]
        public ActionResult<ItemCardDTO> GetItensFromUserId(string userId)
        {
            var itens = _itemService.GetItensFromUserId(userId);
            return Ok(itens);
        }

        [CustomAuthorize]
        [HttpPost()]
        public ActionResult<ItemCardDTO> AddItem(PostItemDTO item)
        {
            var userFromJwt = (User)HttpContext.Items["User"];
            var addedItem = _itemService.AddItem(item, userFromJwt.Id);
            return Ok(addedItem);
        }

        [CustomAuthorize]
        [HttpPut("{itemId}")]
        public ActionResult<ItemDTO> UpdateItem(UpdateItemDTO newItem ,string itemId)
        {
            var updatedItem = _itemService.UpdateItem(newItem, itemId);
            return Ok(updatedItem);
        }

        [CustomAuthorize]
        [HttpDelete("{itemId}")]
        public IActionResult DeleteItem(string itemId) 
        {
            _itemService.DeleteItem(itemId);
            return Ok("Item deletado com sucesso!");
        }
    }
}
