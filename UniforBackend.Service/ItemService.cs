using Microsoft.AspNetCore.Http;
using System.Net;
using UniforBackend.Domain.Exceptions;
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
        private readonly IStorageService _storageService;

        public ItemService(IItemRepo itemRepository, ICategoriaRepo categoriaRepo, IUserRepo userRepo, IStorageService storageService)
        {
            _itemRepository = itemRepository;
            _categoriaRepo = categoriaRepo;
            _userRepo = userRepo;
            _storageService = storageService;
        }

        public ItemDTO GetItemById(string itemId)
        {
            var itemDTO = _itemRepository.GetItemDTOById(itemId);
            if(itemDTO == null)
            {
                throw new CustomException(new ErrorResponse
                {
                    Message = "Item não encontrado.",
                    StatusCode = (int)HttpStatusCode.NotFound,
                });
            }
            return itemDTO;
        }

        public ItemDTO AddItem(PostItemDTO item, string userId)
        {
            var subCategoria = _categoriaRepo.GetSubCategoriaByName(item.SubCategoria);
            if(subCategoria == null)
            {
                throw new CustomException(new ErrorResponse
                {
                    Message = "Categoria inexistente",
                    StatusCode = (int)HttpStatusCode.BadRequest,
                });
            }
            var vendedor = _userRepo.GetById(userId);

            var addedItem = new Item()
            {
                Nome = item.Nome,
                Descricao = item.Descricao,
                Preco = item.Preco,
                AceitaTroca = item.AceitaTroca,
                UserId = userId,
                SubCategoriaId = subCategoria.Id,
            };

            _itemRepository.Add(addedItem);
            _itemRepository.SaveChanges();

            string fileExt = Path.GetExtension(item.Foto.FileName);
            addedItem.Foto = $"https://uniforbackend-test.s3.amazonaws.com/{addedItem.Id}{fileExt}";          
            
            _itemRepository.SaveChanges();
            _storageService.UploadFileAsync(item.Foto, addedItem.Id, fileExt);

            var response = new ItemDTO(addedItem, vendedor);

            return response;
        }

        public PagedResult<ItemDTO> GetAllItens(string? search, int pagina, int pageSize)
        {
            var itens = _itemRepository.GetAllItens(search, pagina, pageSize);
            return itens;
        }

        public UserItensDTO GetItensFromUserId(string userId)
        {
            var itensFromUser = _itemRepository.GetItensFromUserId(userId);
            if (itensFromUser == null)
            {
                throw new CustomException(new ErrorResponse
                {
                    Message = "Não foi possível encontrar itens deste usuário.",
                    StatusCode = (int)HttpStatusCode.NotFound,
                });
            }
            return itensFromUser;
        }

        public PagedResult<ItemDTO> GetItensByCategory(string category, int pagina, int pageSize)
        {
            var allItens = _itemRepository.GetItensByCategoryOrSub(category, pagina, pageSize);
            return allItens;
        }

        public UserItensDTO GetItensPendentes(string userId)
        {
            var itensPendentes = _itemRepository.GetItensPendentesFromUserId(userId);
            if(itensPendentes == null)
            {
                throw new CustomException(new ErrorResponse
                {
                    Message = "Não foi possível encontrar itens pendentes deste usuário.",
                    StatusCode = (int)HttpStatusCode.NotFound,
                });
            }
            return itensPendentes;
        }

        public ItemDTO UpdateItem(UpdateItemDTO newItem, string itemId)
        {
            var itemToUpdate = _itemRepository.GetById(itemId);
            if (itemToUpdate == null)
            {
                throw new CustomException(new ErrorResponse
                {
                    Message = "Item não encontrado.",
                    StatusCode = (int)HttpStatusCode.NotFound
                });
            }

            var vendedor = _userRepo.GetById(itemToUpdate.UserId);

            newItem.UpdateFields(itemToUpdate);
            _itemRepository.SaveChanges();

            var response = new ItemDTO(itemToUpdate, vendedor);
            return response;
        }

        public void VendeItem(string itemId)
        {
            var item = _itemRepository.GetById(itemId);
            
            if (item == null)
            {
                throw new CustomException(new ErrorResponse
                {
                    Message = "Item não encontrado.",
                    StatusCode = (int)HttpStatusCode.NotFound
                });
            }

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
