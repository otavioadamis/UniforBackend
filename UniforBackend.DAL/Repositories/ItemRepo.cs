using Microsoft.EntityFrameworkCore;
using UniforBackend.DAL.Data;
using UniforBackend.DAL.Helpers;
using UniforBackend.Domain.Exceptions;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Models.DTOs.ItemTOs;
using UniforBackend.Domain.Models.DTOs.PageTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.DAL.Repositories
{
    public class ItemRepo : IItemRepo
    {
        private readonly AppDbContext _dbContext;
        public ItemRepo(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public Item Add(Item thisItem)
        {
            _dbContext.Itens.Add(thisItem);
            return thisItem;
        }

        public Item GetById(string _id)
        {
            var item = _dbContext.Itens.FirstOrDefault(x => x.Id == _id);
            return item;
        }

        public void Delete(string _id)
        {
            var item = _dbContext.Itens.FirstOrDefault(x => x.Id == _id);
            _dbContext.Itens.Remove(item);
        }

        public ItemDTO GetItemDTOById(string _id)
        {
            var itemDTO = (from Item item in _dbContext.Itens
                           where item.Id == _id
                           join user in _dbContext.Users on item.UserId equals user.Id
                           select new ItemDTO()
                           {
                               Id = item.Id,
                               Nome = item.Nome,
                               Descricao = item.Descricao,
                               Preco = item.Preco,
                               AceitaTroca = item.AceitaTroca,
                               Foto = item.Foto,
                               PostadoEm = item.PostadoEm,
                               NomeVendedor = user.Nome,
                               VendedorId = user.Id
                           }
                ).FirstOrDefault();
            return itemDTO;
        }

        public UserItensDTO GetItensFromUserId(string userId, int pagina)
        {
            IQueryable<Item> itemQuery = _dbContext.Itens;

            var queryResult = (from item in itemQuery
                               where item.UserId == userId && item.isAprovado == true
                               select new ItemCardDTO()
                               {
                                   Id = item.Id,
                                   Nome = item.Nome,
                                   Preco = item.Preco,
                                   Descricao = item.Descricao,
                                   PostadoEm = item.PostadoEm,
                                   AceitaTroca = item.AceitaTroca,
                                   Foto = item.Foto,
                               }).OrderByDescending(x => x.PostadoEm);
            var pagedResult = PaginationHelper.Paginate(queryResult, pagina, 5f);

            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null) { return null; }

            UserItensDTO response = new UserItensDTO()
            {
                UserId = user.Id,
                Nome = user.Nome,
                PagedResult = pagedResult,
            };

            return response;
        }

        public UserItensDTO GetItensPendentesFromUserId(string userId, int pagina)
        {
            IQueryable<Item> itemQuery = _dbContext.Itens;

            var queryResult = (from item in itemQuery
                               where item.UserId == userId && item.isAprovado == false
                               select new ItemCardDTO()
                               {
                                   Id = item.Id,
                                   Nome = item.Nome,
                                   Preco = item.Preco,
                                   Descricao = item.Descricao,
                                   PostadoEm = item.PostadoEm,
                                   AceitaTroca = item.AceitaTroca,
                                   Foto = item.Foto,
                               }).OrderByDescending(x => x.PostadoEm);
            var pagedResult = PaginationHelper.Paginate(queryResult, pagina, 5f);

            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null) { return null; }

            UserItensDTO response = new UserItensDTO()
            {
                UserId = user.Id,
                Nome = user.Nome,
                PagedResult = pagedResult,
            };

            return response;
        }

        public PagedResult<ItemDTO> GetAllItens(string? search, int pagina)
        {
            IQueryable<Item> itemQuery = _dbContext.Itens;

            if (search != null)
            {
                itemQuery = itemQuery.Where(i => EF.Functions.ILike(i.Nome, $"%{search}%"));
            }

            var queryResult = (from item in itemQuery
                               where item.IsVendido == false && item.isAprovado == true
                               join user in _dbContext.Users on item.UserId equals user.Id
                               select new ItemDTO()
                               {
                                   Id = item.Id,
                                   Nome = item.Nome,
                                   Preco = item.Preco,
                                   Descricao = item.Descricao,
                                   PostadoEm = item.PostadoEm,
                                   AceitaTroca = item.AceitaTroca,
                                   Foto = item.Foto,
                                   VendedorId = user.Id,
                                   NomeVendedor = user.Nome,
                               }).OrderByDescending(x => x.PostadoEm);
            var pagedResult = PaginationHelper.Paginate(queryResult, pagina, 5f);
           
            return pagedResult;
        }

        public PagedResult<ItemDTO> GetAllUnauthorized(int pagina)
        {
            IQueryable<Item> itemQuery = _dbContext.Itens;

            var queryResult = from item in itemQuery
                              where item.isAprovado == false
                              join user in _dbContext.Users on item.UserId equals user.Id
                              select new ItemDTO()
                              {
                                  Id = item.Id,
                                  Nome = item.Nome,
                                  Preco = item.Preco,
                                  Descricao = item.Descricao,
                                  PostadoEm = item.PostadoEm,
                                  AceitaTroca = item.AceitaTroca,
                                  Foto = item.Foto,
                                  VendedorId = user.Id,
                                  NomeVendedor = user.Nome,
                              };
            var pagedResult = PaginationHelper.Paginate(queryResult, pagina, 5f);
            
            return pagedResult;
        }

        public PagedResult<ItemDTO> GetItensByCategoryOrSub(string name, int pagina)
        {
            IQueryable<Item> itemQuery = _dbContext.Itens;

            var queryResult = (
                from item in itemQuery
                where item.IsVendido == false && item.isAprovado == true
                join subcategory in _dbContext.SubCategorias on item.SubCategoriaId equals subcategory.Id
                join category in _dbContext.Categorias on subcategory.CategoriaId equals category.Id
                where subcategory.Nome == name || category.Nome == name
                join user in _dbContext.Users on item.UserId equals user.Id
                select new ItemDTO()
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Preco = item.Preco,
                    Descricao = item.Descricao,
                    PostadoEm = item.PostadoEm,
                    AceitaTroca = item.AceitaTroca,
                    Foto = item.Foto,
                    VendedorId = user.Id,
                    NomeVendedor = user.Nome,
                }).OrderByDescending(x => x.PostadoEm);
            var pagedResult = PaginationHelper.Paginate(queryResult, pagina, 5f);

            return pagedResult;
        }
    }
}
