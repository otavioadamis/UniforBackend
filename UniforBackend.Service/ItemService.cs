using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.ItemTOs;
using UniforBackend.Domain.Models.DTOs.PageTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Service
{
    public class ItemService : IItemService
    {
        private readonly IItemRepo _itemRepository;
        private readonly ICategoriaRepo _categoriaRepo;

        public ItemService(IItemRepo itemRepository, ICategoriaRepo categoriaRepo)
        {
            _itemRepository = itemRepository;
            _categoriaRepo = categoriaRepo;
        }

        public ItemCardDTO AddItem(PostItemDTO item, string userId)
        {
            var subCategoria = _categoriaRepo.GetSubCategoriaByName(item.SubCategoria);
            
            var addedItem = new Item()
            {
                Nome = item.Nome,
                Descricao = item.Descricao,
                Preco = item.Preco,
                AceitaTroca = item.AceitaTroca,
                UserId = userId,
                Foto = item.Foto,
                SubCategoriaId = subCategoria.Id,
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


        public PagedResult<ItemCardDTO> GetAllItens(string? search, int pagina)
        {
            var itens = _itemRepository.GetAllItens(search, pagina);
            return itens;
        }

        public IEnumerable<ItemCardDTO> GetItensFromUserId(string userId)
        {
            var itens = _itemRepository.GetItensFromUserId(userId);
            return itens;
        }

        public IEnumerable<ItemCardDTO> GetItensByCategory(string category)
        {
            var allItens = _itemRepository.GetItensByCategoryOrSub(category);
            return allItens;
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
