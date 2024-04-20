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
        public ItemDTO GetItemDTOById(string _id);
        public UserItensDTO GetItensFromUserId(string userId, int pagina);
        public PagedResult<ItemDTO> GetAllItens(string? search,int pagina);
        public PagedResult<ItemDTO> GetAllUnauthorized(int pagina);
        public PagedResult<ItemDTO> GetItensByCategoryOrSub(string name, int pagina);
        public UserItensDTO GetItensPendentesFromUserId(string userId, int pagina);
    }
}
