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
        private readonly IUserRepo _userRepo;

        public ItemService(IItemRepo itemRepository, ICategoriaRepo categoriaRepo, IUserRepo userRepo)
        {
            _itemRepository = itemRepository;
            _categoriaRepo = categoriaRepo;
            _userRepo = userRepo;
        }

        public ItemDTO AddItem(PostItemDTO item, string userId)
        {
            var subCategoria = _categoriaRepo.GetSubCategoriaByName(item.SubCategoria);
            var vendedor = _userRepo.GetById(userId);
            
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

            var response = new ItemDTO(addedItem, vendedor);

            return response;
        }


        public PagedResult<ItemDTO> GetAllItens(string? search, int pagina)
        {
            var itens = _itemRepository.GetAllItens(search, pagina);
            return itens;
        }

        public UserItensDTO GetItensFromUserId(string userId, int pagina)
        {
            var itens = _itemRepository.GetItensFromUserId(userId, pagina);
            return itens;
        }

        public PagedResult<ItemDTO> GetItensByCategory(string category, int pagina)
        {
            var allItens = _itemRepository.GetItensByCategoryOrSub(category, pagina);
            return allItens;
        }

        public UserItensDTO GetItensPendentes(string userId, int pagina)
        {
            var itensPendentes = _itemRepository.GetItensPendentesFromUserId(userId, pagina);
            return itensPendentes;
        }

        public ItemDTO UpdateItem(UpdateItemDTO newItem, string itemId)
        {
            var itemToUpdate = _itemRepository.GetById(itemId);
            var vendedor = _userRepo.GetById(itemToUpdate.UserId);

            newItem.UpdateFields(itemToUpdate);
            _itemRepository.SaveChanges();

            var response = new ItemDTO(itemToUpdate, vendedor);
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
