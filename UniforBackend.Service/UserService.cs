using System.Net;
using UniforBackend.Domain.Exceptions;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.UserTOs;
using UniforBackend.Domain.Models.Entities;
using IAuthorizationService = UniforBackend.Domain.Interfaces.IServices.IAuthorizationService;

namespace UniforBackend.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepository;
        private readonly IAuthorizationService _authorizationService;

        public UserService(IUserRepo userRepository, IAuthorizationService authorizationService)
        {
            _userRepository = userRepository;
            _authorizationService = authorizationService;
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

        public User GetById(string userId)
        {
            var response = _userRepository.GetById(userId);
            return response;
        }

        public LoginResponseModel Signup(PostUserDTO thisUser)
        {
            var checkEmail = _userRepository.GetByEmail(thisUser.Email);
            if (checkEmail != null)
            {
                throw new CustomException(new ErrorResponse
                {
                    Message = "Email já está em uso.",
                    StatusCode = (int)HttpStatusCode.BadRequest
                });
            }

            thisUser.Password = BCrypt.Net.BCrypt.HashPassword(thisUser.Password);

            string codigoVerificacao = Guid.NewGuid().ToString();

            var newUser = new User()
            {
                Nome = thisUser.Nome,
                Email = thisUser.Email,
                Matricula = thisUser.Matricula,
                Contato = thisUser.Contato,
                Password = thisUser.Password,
                Foto = thisUser.Foto,
                CodigoVerificacao = codigoVerificacao,
            };

            _userRepository.Add(newUser);
            _userRepository.SaveChanges();

            //envia codigo de verificao + userid em uma rota para o email do usuario.
            var userModel = new UserDTO();
            userModel = userModel.CreateModel(newUser);

            var res = new LoginResponseModel
            {
                Token = "enviar por email, mas so pra teste: " + codigoVerificacao,
                User = userModel
            };
            return res;
        }

        public LoginResponseModel Login(UserLoginDTO thisUser)
        {
            var user = _userRepository.GetByEmail(thisUser.Email) ?? throw new CustomException(new ErrorResponse
            {
                Message = "Email não encontrado.",
                StatusCode = (int)HttpStatusCode.NotFound
            });

            bool isPasswordMatch = BCrypt.Net.BCrypt.Verify(thisUser.Password, user.Password);
            if (!isPasswordMatch)
            {
                throw new CustomException(new ErrorResponse
                {
                    Message = "Senha incorreta.",
                    StatusCode = (int)HttpStatusCode.BadRequest
                });
            }

            if(user.IsVerificado == false)
            {
                throw new CustomException(new ErrorResponse
                {
                    Message = "Email ainda não confirmado!",
                    StatusCode = (int)HttpStatusCode.Unauthorized
                });
            }

            string token = _authorizationService.CreateToken(user);

            var userModel = new UserDTO();
            userModel = userModel.CreateModel(user);

            var res = new LoginResponseModel
            {
                Token = token,
                User = userModel
            };
            return res;
        }

        public UserDTO UpdateUser(UpdateUserDTO updatedUser, string userId)
        {
            var user = _userRepository.GetById(userId);
            updatedUser.UpdateFields(user);
            _userRepository.SaveChanges();
            var response = new UserDTO();
            response.CreateModel(user);
            return response;
        }

        public void DeleteUser(string userId)
        {
            _userRepository.Delete(userId);
            _userRepository.SaveChanges();
        }
    }
}
