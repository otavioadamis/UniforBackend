using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.AdminTOs;
using UniforBackend.Domain.Models.DTOs.ItemTOs;
using UniforBackend.Domain.Models.DTOs.PageTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Service
{
    public class AdminService : IAdminService
    {
        private readonly IItemRepo _itemRepository;

        public AdminService(IItemRepo itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public void AvaliarItem(AvaliarItemDTO avaliacao)
        {
            string itemId = avaliacao.Id;
            bool aprovado = avaliacao.Aprovado;
            Item item = _itemRepository.GetById(itemId);
            if (item != null)
            {
                if (aprovado)
                {
                    item.isAprovado = true;
                }
                else
                {
                    _itemRepository.Delete(itemId);
                }
            }
            _itemRepository.SaveChanges();
        }

        public void DeleteItem(string itemId)
        {
            _itemRepository.Delete(itemId);
            _itemRepository.SaveChanges();
        }

        public PagedResult<ItemDTO> GetAllUnauthorized(int pagina, int pageSize)
        {
            var itens = _itemRepository.GetAllUnauthorized(pagina, pageSize);
            return itens;
        }
    }
}
