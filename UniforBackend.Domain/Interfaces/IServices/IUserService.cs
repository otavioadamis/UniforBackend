using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.DTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Interfaces.IServices
{
    public interface IUserService
    {
        public UserDTO GetUserById(string userId);
        public UserDTO AddUser(PostUserDTO user);
        public UserDTO UpdateUser(UpdateUserDTO updatedUser, string userId);
        public void DeleteUser(string userId);
    }
}
