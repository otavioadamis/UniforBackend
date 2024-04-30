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
        private readonly IImagemRepo _imagemRepo;

        public ItemService(IItemRepo itemRepository, 
            ICategoriaRepo categoriaRepo, 
            IUserRepo userRepo, 
            IStorageService storageService, 
            IImagemRepo imagemRepo)
        {
            _itemRepository = itemRepository;
            _categoriaRepo = categoriaRepo;
            _userRepo = userRepo;
            _storageService = storageService;
            _imagemRepo = imagemRepo;
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

        public async Task<ItemDTO> AddItem(PostItemDTO item, string userId)
        {
            if (item.Foto.Count() > 5)
            {
                throw new CustomException(new ErrorResponse()
                {
                    Message = "Limite máximo de imagens ultrapassado, apenas 5 imagens!",
                    StatusCode= (int)HttpStatusCode.BadRequest,
                });
            }

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
                MostrarContato = item.MostrarContato,
                UserId = userId,
                SubCategoriaId = subCategoria.Id,
            };

            _itemRepository.Add(addedItem);
            _itemRepository.SaveChanges();

            for(int i = 0; i < item.Foto.Count(); i++)
            {
                string fileExt = Path.GetExtension(item.Foto[i].FileName);
                var newImagem = new Imagem()
                {
                    ItemId = addedItem.Id,
                    Extensao = fileExt,
                    Index = i + 1,
                };
                
                _imagemRepo.Add(newImagem);
                _imagemRepo.SaveChanges();
                
                await _storageService.UploadFileAsync(item.Foto[i], addedItem.Id, fileExt, i+1);
            }
            var response = _itemRepository.GetItemDTOById(addedItem.Id);
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

            newItem.UpdateFields(itemToUpdate);
            _itemRepository.SaveChanges();

            var response = _itemRepository.GetItemDTOById(itemToUpdate.Id);
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
