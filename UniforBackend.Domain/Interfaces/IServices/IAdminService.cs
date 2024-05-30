using UniforBackend.Domain.Models.DTOs.AdminTOs;
using UniforBackend.Domain.Models.DTOs.ItemTOs;
using UniforBackend.Domain.Models.DTOs.PageTOs;

namespace UniforBackend.Domain.Interfaces.IServices
{
    public interface IAdminService
    {
        public Task AvaliarItem(AvaliarItemDTO avaliacao);
        public Task DeleteItem(string itemId);
        public PagedResult<ItemReviewDTO> GetAllUnauthorized(int pagina, int pageSize);
    }
}
