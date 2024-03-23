using UniforBackend.DAL.Data;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.DAL.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _dbContext;
        public UserRepo(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public User Add(User thisUser)
        {
            _dbContext.Users.Add(thisUser);
            return thisUser;
        }

        public User GetById(string _id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == _id);
            return user;
        }

        public User GetByEmail(string email)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == email);
            return user;
        }

        public User Delete(string _id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == _id);
            _dbContext.Users.Remove(user);
            return user;
        }
    }
}
