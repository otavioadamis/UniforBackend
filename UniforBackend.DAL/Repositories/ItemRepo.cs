using UniforBackend.DAL.Data;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Models.DTOs.ItemTOs;
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

        //TODO -> Paginação aqui também, eu acho? ( Evitar problema no caso do usuario ter postado muitos itens )
        public IEnumerable<ItemCardDTO> GetItensFromUserId(string userId)
        {
            var allItens = _dbContext.Itens.Where(item => item.UserId == userId)
            .Select(item => new ItemCardDTO
            {
                Id = item.Id,
                Nome = item.Nome,
                Preco = item.Preco,
            })
            .ToList();
            
            return allItens;
        }

        //Retorna 10 itens por pagina
        public ListItemCardResponse GetAllItens(int pagina)
        {
            if(_dbContext.Itens == null)
            {
                return null;
            }

            var pageResults = 10f;
            var pageCount = Math.Ceiling(_dbContext.Itens.Count() / pageResults);

            var itens = _dbContext.Itens
                .Skip((pagina - 1) * (int)pageResults)
                .Take((int)pageResults)
                .Where(i => i.IsVendido == false)
                .Select(item => new ItemCardDTO
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Preco = item.Preco,
                })
                .ToList();

            var response = new ListItemCardResponse()
            {
                Items = itens,
                PageAtual = pagina,
                Pages = (int)pageCount
            };
            return response;
        }
    }
}
