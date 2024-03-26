using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs;
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

        public UserDTO AddUser(PostUserDTO user)
        {
            User newUser = new User()
            {
                Nome = user.Nome,
                Email = user.Email,
                Matricula = user.Matricula,
                Foto = user.Foto
            };
            _userRepository.Add(newUser);
            _userRepository.SaveChanges();
            var response = new UserDTO
            {
                Nome = newUser.Nome,
                Email = newUser.Email,
                Matricula = newUser.Matricula,
                Foto = newUser.Foto
            };
            return response;
        }

        public void DeleteUser(string userId)
        {
            _userRepository.Delete(userId);
            _userRepository.SaveChanges();
        }

        public UserDTO GetUserById(string userId)
        {
            var user = _userRepository.GetById(userId);
            var response = new UserDTO()
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email,
                Matricula = user.Matricula,
                Foto = user.Foto
            };
            return response;
        }

        public UserDTO UpdateUser(UpdateUserDTO updatedUser, string userId)
        {
            var user = _userRepository.GetById(userId);
            updatedUser.UpdateFields(user);
            _userRepository.SaveChanges();
            var response = new UserDTO
            {
                Nome = user.Nome,
                Email = user.Email,
                Matricula = user.Matricula,
                Foto = user.Foto
            };
            return response;
        }
    }
}
