using UniforBackend.Domain.Models.DTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Interfaces.IServices
{
    public interface IItemService
    {
        public ListItemCardResponse GetAllItens(int pagina);
        public IEnumerable<ItemCardDTO> GetItensFromUserId(string userId);
        public ItemCardDTO AddItem(PostItemDTO item, string userId);
        public ItemDTO UpdateItem(UpdateItemDTO newItem, string itemId);
        void DeleteItem(string itemId);
    }
}
