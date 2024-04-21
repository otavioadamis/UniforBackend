using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniforBackend.API.Authorization;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.ItemTOs;
using UniforBackend.Domain.Models.DTOs.PageTOs;
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

        [HttpGet("{itemId}")]
        public ActionResult<ItemDTO> GetItemById(string itemId)
        {
            var item = _itemService.GetItemById(itemId);
            return Ok(item);
        }

        [HttpGet("itens/{pagina}")]
        public ActionResult<PagedResult<ItemDTO>> GetItensFromPagina(string? search, int pagina = 1, int pageSize = 10)
        {
            if (pagina < 1) { pagina = 1; }
            var itens = _itemService.GetAllItens(search, pagina, pageSize);
            return Ok(itens);
        }

        [HttpGet("categorias/{categoria}")]
        public ActionResult<PagedResult<ItemDTO>> GetItensByCategory(string categoria, int pagina = 1, int pageSize = 10)
        {
            if (pagina < 1) { pagina = 1; }
            var allItems = _itemService.GetItensByCategory(categoria, pagina, pageSize);
            return Ok(allItems);
        }

        [HttpGet("user/{userId}")]
        public ActionResult<UserItensDTO> GetItensFromUserId(string userId)
        {
            var itens = _itemService.GetItensFromUserId(userId);
            return Ok(itens);
        }

        [CustomAuthorize]
        [HttpGet("pendentes")]
        public ActionResult<UserItensDTO> GetItensPendentes()
        {
            var userFromJwt = (User)HttpContext.Items["User"];
            var itensPendentes = _itemService.GetItensPendentes(userFromJwt.Id);
            return Ok(itensPendentes);
        }

        [CustomAuthorize]
        [HttpPost()]
        public ActionResult<ItemDTO> AddItem([FromForm] PostItemDTO item)
        {
            var userFromJwt = (User)HttpContext.Items["User"];
            var addedItem = _itemService.AddItem(item, userFromJwt.Id);
            return Ok(addedItem);
        }

        [CustomAuthorize]
        [HttpPut("{itemId}")]
        public ActionResult<ItemDTO> UpdateItem(UpdateItemDTO newItem, string itemId)
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
