using UniforBackend.Domain.Models.DTOs.AdminTOs;
using UniforBackend.Domain.Models.DTOs.ItemTOs;
using UniforBackend.Domain.Models.DTOs.PageTOs;

namespace UniforBackend.Domain.Interfaces.IServices
{
    public interface IAdminService
    {
        public void AvaliarItem(AvaliarItemDTO avaliacao);
        public void DeleteItem(string itemId);
        public PagedResult<ItemDTO> GetAllUnauthorized(int pagina, int pageSize);
    }
}
