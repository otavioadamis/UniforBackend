using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs;
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
            // todo -> checar se user existe. 

            var addedItem = new Item()
            {
                Cor = item.Cor,
                Descricao = item.Descricao,
                Nome = item.Nome,
                Preco = item.Preco,
                Tamanho = item.Tamanho,
                UserId = userId,
                Quantidade = 1, // todo -> tenho que tirar quantidade, esqueci
            };

            _itemRepository.Add(addedItem);
            _itemRepository.SaveChanges();

            var response = new ItemCardDTO()
            {
                Id = addedItem.Id,
                Nome = addedItem.Nome,
                Preco = addedItem.Preco,
                Tamanho= addedItem.Tamanho
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
                Cor = itemToUpdate.Cor,
                Tamanho = itemToUpdate.Tamanho
            };

            return response;
        }

        public void DeleteItem(string itemId)
        {
            _itemRepository.Delete(itemId);
            _itemRepository.SaveChanges();
        }
    }
}
