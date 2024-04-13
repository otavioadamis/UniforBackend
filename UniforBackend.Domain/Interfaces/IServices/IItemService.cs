using UniforBackend.Domain.Models.DTOs.ItemTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Interfaces.IServices
{
    public interface IItemService
    {
        public ListItemCardResponse GetAllItens(string? search, int pagina);
        public IEnumerable<ItemCardDTO> GetItensFromUserId(string userId);
        public IEnumerable<ItemCardDTO> GetItensByCategory(string category);
        public ItemCardDTO AddItem(PostItemDTO item, string userId);
        public ItemDTO UpdateItem(UpdateItemDTO newItem, string itemId);
        public void VendeItem(string itemId);
        void DeleteItem(string itemId);
    }
}
