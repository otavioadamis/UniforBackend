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
        private readonly IItemService _itemService;

        public AdminService(IItemRepo itemRepository, IItemService itemService)
        {
            _itemRepository = itemRepository;
            _itemService = itemService;
        }

        public async Task AvaliarItem(AvaliarItemDTO avaliacao)
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
                    await _itemService.DeleteItem(itemId);
                }
            }
        }

        public async Task DeleteItem(string itemId)
        {
            await _itemService.DeleteItem(itemId);
        }

        public PagedResult<ItemReviewDTO> GetAllUnauthorized(int pagina, int pageSize)
        {
            var itens = _itemRepository.GetAllUnauthorized(pagina, pageSize);
            return itens;
        }
    }
}
