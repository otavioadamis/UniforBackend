using UniforBackend.DAL.Data;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.DAL.Repositories
{
    public class CategoriaRepo : ICategoriaRepo
    {
        private readonly AppDbContext _dbContext;
        public CategoriaRepo(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public SubCategoria GetSubCategoriaByName(string name) 
        {
            var subCategoria = _dbContext.SubCategorias.FirstOrDefault(x => x.Nome == name);
            return subCategoria;
        }

    }
}
