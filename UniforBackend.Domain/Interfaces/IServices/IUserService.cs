using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Interfaces.IServices
{
    public interface IUserService
    {
        public User GetUserById(string userId);
        public User AddUser(User user);
        public User UpdateUser(User updatedUser, string userId);
        public User DeleteUser(string userId);
    }
}
