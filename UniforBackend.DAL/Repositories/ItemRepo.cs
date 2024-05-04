using Microsoft.EntityFrameworkCore;
using UniforBackend.DAL.Data;
using UniforBackend.DAL.Helpers;
using UniforBackend.Domain.Exceptions;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Models.DTOs.ImageTOs;
using UniforBackend.Domain.Models.DTOs.ItemTOs;
using UniforBackend.Domain.Models.DTOs.PageTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.DAL.Repositories
{
    public class ItemRepo : IItemRepo
    {
        private readonly AppDbContext _dbContext;
        private readonly IImagemRepo _imagemRepo;
        public ItemRepo(AppDbContext appDbContext, IImagemRepo imagemRepo)
        {
            _dbContext = appDbContext;
            _imagemRepo = imagemRepo;
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
                           join subcategory in _dbContext.SubCategorias on item.SubCategoriaId equals subcategory.Id
                           join imagens in _dbContext.Imagens on item.Id equals imagens.ItemId into imagensgroup
                           select new ItemDTO()
                           {
                               Id = item.Id,
                               Nome = item.Nome,
                               Descricao = item.Descricao,
                               Preco = item.Preco,
                               AceitaTroca = item.AceitaTroca,
                               PostadoEm = item.PostadoEm,
                               NomeVendedor = user.Nome,
                               VendedorId = user.Id,
                               MostrarContato = item.MostrarContato,
                               SubCategoria = subcategory.Nome,
                               Imagens = imagensgroup.Select(x => new ImagemDTO() { Id = x.Id, Index = x.Index, URL = "" }).ToArray(),
                           }
                ).FirstOrDefault();
            return itemDTO;
        }

        public UserItensDTO GetItensFromUserId(string userId)
        {
            IQueryable<Item> itemQuery = _dbContext.Itens;

            var queryResult = (from item in itemQuery
                               where 
                               item.UserId == userId 
                               && item.isAprovado == true 
                               && item.IsVendido == false
                               join subcategory in _dbContext.SubCategorias on item.SubCategoriaId equals subcategory.Id
                               select new ItemCardDTO()
                               {
                                   Id = item.Id,
                                   Nome = item.Nome,
                                   Preco = item.Preco,
                                   Descricao = item.Descricao,
                                   PostadoEm = item.PostadoEm,
                                   AceitaTroca = item.AceitaTroca,
                                   SubCategoria = subcategory.Nome,
                               }).OrderByDescending(x => x.PostadoEm).ToList();

            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null) { return null; }

            UserItensDTO response = new UserItensDTO()
            {
                UserId = user.Id,
                Nome = user.Nome,
                Itens = queryResult,
            };
            return response;
        }

        public UserItensDTO GetItensPendentesFromUserId(string userId)
        {
            IQueryable<Item> itemQuery = _dbContext.Itens;

            var queryResult = (from item in itemQuery
                               where 
                               item.UserId == userId 
                               && item.isAprovado == false
                               join subcategory in _dbContext.SubCategorias on item.SubCategoriaId equals subcategory.Id
                               select new ItemCardDTO()
                               {
                                   Id = item.Id,
                                   Nome = item.Nome,
                                   Preco = item.Preco,
                                   Descricao = item.Descricao,
                                   PostadoEm = item.PostadoEm,
                                   AceitaTroca = item.AceitaTroca,
                                   SubCategoria = subcategory.Nome,
                               }).OrderByDescending(x => x.PostadoEm).ToList();

            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null) { return null; }

            UserItensDTO response = new UserItensDTO()
            {
                UserId = user.Id,
                Nome = user.Nome,
                Itens = queryResult,
            };

            return response;
        }

        public PagedResult<ItemDTO> GetAllItens(string? search, int pagina, int pageSize)
        {
            IQueryable<Item> itemQuery = _dbContext.Itens;

            if (search != null)
            {
                itemQuery = itemQuery.Where(i => EF.Functions.ILike(i.Nome, $"%{search}%"));
            }

            var queryResult = (from item in itemQuery
                               where 
                               item.IsVendido == false 
                               && item.isAprovado == true
                               join user in _dbContext.Users on item.UserId equals user.Id
                               join subcategory in _dbContext.SubCategorias on item.SubCategoriaId equals subcategory.Id
                               join imagens in _dbContext.Imagens on item.Id equals imagens.ItemId into imagensgroup
                               select new ItemDTO()
                               {
                                   Id = item.Id,
                                   Nome = item.Nome,
                                   Descricao = item.Descricao,
                                   Preco = item.Preco,
                                   AceitaTroca = item.AceitaTroca,
                                   PostadoEm = item.PostadoEm,
                                   NomeVendedor = user.Nome,
                                   VendedorId = user.Id,
                                   MostrarContato = item.MostrarContato,
                                   SubCategoria = subcategory.Nome,
                                   Imagens = imagensgroup.Select(x => new ImagemDTO() { Id = x.Id, Index = x.Index, URL = "" }).ToArray(),
                               }).OrderByDescending(x => x.PostadoEm);
            var pagedResult = PaginationHelper.Paginate(queryResult, pagina, pageSize);
           
            return pagedResult;
        }

        public PagedResult<ItemDTO> GetAllUnauthorized(int pagina, int pageSize)
        {
            IQueryable<Item> itemQuery = _dbContext.Itens;
            IQueryable<Imagem> imagemQuery = _dbContext.Imagens;

            var queryResult = from item in itemQuery
                              where item.isAprovado == false
                              join user in _dbContext.Users on item.UserId equals user.Id
                              join subcategory in _dbContext.SubCategorias on item.SubCategoriaId equals subcategory.Id
                              select new ItemDTO()
                              {
                                  Id = item.Id,
                                  Nome = item.Nome,
                                  Descricao = item.Descricao,
                                  Preco = item.Preco,
                                  AceitaTroca = item.AceitaTroca,
                                  PostadoEm = item.PostadoEm,
                                  NomeVendedor = user.Nome,
                                  VendedorId = user.Id,
                                  MostrarContato = item.MostrarContato,
                                  SubCategoria = subcategory.Nome,
                                  Imagens = _imagemRepo.GetAllByItemId(item.Id).ToArray(),
                              };
            var pagedResult = PaginationHelper.Paginate(queryResult, pagina, pageSize);
            
            return pagedResult;
        }

        public PagedResult<ItemDTO> GetItensByCategoryOrSub(string name, int pagina, int pageSize)
        {
            IQueryable<Item> itemQuery = _dbContext.Itens;

            var queryResult =  (from item in itemQuery
                                where 
                                item.IsVendido == false 
                                && item.isAprovado == true
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
                                    VendedorId = user.Id,
                                    NomeVendedor = user.Nome,
                                    MostrarContato = item.MostrarContato,
                                    SubCategoria = subcategory.Nome,
                                    Imagens = _imagemRepo.GetAllByItemId(item.Id).ToArray(),
                                }).OrderByDescending(x => x.PostadoEm);
            var pagedResult = PaginationHelper.Paginate(queryResult, pagina, pageSize);

            return pagedResult;
        }
    }
}
