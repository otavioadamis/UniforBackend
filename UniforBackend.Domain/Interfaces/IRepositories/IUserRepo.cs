using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Interfaces.IRepositories
{
    public interface IUserRepo
    {
        public void SaveChanges();

        public User Add(User thisUser);

        public User GetById(string _id);

        public User GetByEmail(string email);

        public User Delete(string _id);
    }
}
