using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.ItemTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Service
{
    public class ItemService : IItemService
    {
        private readonly IItemRepo _itemRepository;

        public ItemService(IItemRepo itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public ItemCardDTO AddItem(PostItemDTO item, string userId)
        {
            var addedItem = new Item()
            {
                Nome = item.Nome,
                Descricao = item.Descricao,
                Preco = item.Preco,
                AceitaTroca = item.AceitaTroca,
                /* PostadoEm = DateOnly.FromDateTime(DateTime.UtcNow)*/
                UserId = userId,
                Foto = item.Foto,
            };

            _itemRepository.Add(addedItem);
            _itemRepository.SaveChanges();

            var response = new ItemCardDTO()
            {
                Id = addedItem.Id,
                Nome = addedItem.Nome,
                Preco = addedItem.Preco,
                AceitaTroca = addedItem.AceitaTroca,
                Foto = addedItem.Foto
            };

            return response;
        }


        public ListItemCardResponse GetAllItens(int pagina)
        {
            var itens = _itemRepository.GetAllItens(pagina);
            return itens;
        }

        public IEnumerable<ItemCardDTO> GetItensFromUserId(string userId)
        {
            var itens = _itemRepository.GetItensFromUserId(userId);
            return itens;
        }

        public ItemDTO UpdateItem(UpdateItemDTO newItem, string itemId)
        {
            var itemToUpdate = _itemRepository.GetById(itemId);

            newItem.UpdateFields(itemToUpdate);
            _itemRepository.SaveChanges();

            var response = new ItemDTO()
            {
                Id = itemToUpdate.Id,
                Nome = itemToUpdate.Nome,
                Preco = itemToUpdate.Preco,
                Descricao = itemToUpdate.Descricao,
                AceitaTroca = itemToUpdate.AceitaTroca,
                PostadoEm = itemToUpdate.PostadoEm,
                Foto = itemToUpdate.Foto
            };
            return response;
        }

        public void VendeItem(string itemId)
        {
            var item = _itemRepository.GetById(itemId);
            item.IsVendido = true;
            _itemRepository.SaveChanges();
        }

        public void DeleteItem(string itemId)
        {
            _itemRepository.Delete(itemId);
            _itemRepository.SaveChanges();
        }
    }
}
