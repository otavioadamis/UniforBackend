using UniforBackend.Domain.Models.DTOs.ItemTOs;
using UniforBackend.Domain.Models.DTOs.PageTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Interfaces.IServices
{
    public interface IItemService
    {
        public PagedResult<ItemCardDTO> GetAllItens(int pagina);
        public IEnumerable<ItemCardDTO> GetItensFromUserId(string userId);
        public ItemCardDTO AddItem(PostItemDTO item, string userId);
        public ItemDTO UpdateItem(UpdateItemDTO newItem, string itemId);
        public void VendeItem(string itemId);
        void DeleteItem(string itemId);
    }
}
