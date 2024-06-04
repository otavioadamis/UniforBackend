using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.DTOs.ItemTOs;
using UniforBackend.Domain.Models.DTOs.PageTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Interfaces.IRepositories
{
    public interface IItemRepo
    {
        public void SaveChanges();
        public Item Add(Item thisItem);
        public Item GetById(string _id);
        public void Delete(string _id);
        public ItemComImagensDTO GetItemDTOById(string _id);
        public UserItensDTO GetItensFromUserId(string userId);
        public int CountOfItensFromUserIdFromToday(string userId);
        public PagedResult<ItemDTO> GetAllItens(string? search, int pagina, int pageSize);
        public PagedResult<ItemReviewDTO> GetAllUnauthorized(int pagina, int pageSize);
        public PagedResult<ItemDTO> GetItensByCategoryOrSub(string name, int pagina, int pageSize);
        public UserItensDTO GetItensPendentesFromUserId(string userId);
    }
}
