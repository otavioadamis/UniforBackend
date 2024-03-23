using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepository;

        public UserService(IUserRepo userRepository)
        {
            _userRepository = userRepository;
        }

        public User AddUser(User user)
        {
            _userRepository.Add(user);
            _userRepository.SaveChanges();
            return user;
        }

        public User DeleteUser(string userId)
        {
            var user = _userRepository.Delete(userId);
            _userRepository.SaveChanges();
            return user;
        }

        public User GetUserById(string userId)
        {
            var user = _userRepository.GetById(userId);
            return user;
        }

        public User UpdateUser(User updatedUser, string userId)
        {
            var user = _userRepository.GetById(userId);
            user.Nome = updatedUser.Nome;
            user.Email = updatedUser.Email;
            user.Matricula = updatedUser.Matricula;
            _userRepository.SaveChanges();
            return user;
        }
    }
}
