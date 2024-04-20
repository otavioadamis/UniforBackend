using UniforBackend.Domain.Models.DTOs.ItemTOs;
using UniforBackend.Domain.Models.DTOs.PageTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Interfaces.IServices
{
    public interface IItemService
    {
        public ItemDTO GetItemById(string itemId);
        public PagedResult<ItemDTO> GetAllItens(string? search, int pagina);
        public UserItensDTO GetItensFromUserId(string userId, int pagina);
        public PagedResult<ItemDTO> GetItensByCategory(string category, int pagina);
        public UserItensDTO GetItensPendentes(string userId, int pagina);
        public ItemDTO AddItem(PostItemDTO item, string userId);
        public ItemDTO UpdateItem(UpdateItemDTO newItem, string itemId);
        public void VendeItem(string itemId);
        void DeleteItem(string itemId);
    }
}
