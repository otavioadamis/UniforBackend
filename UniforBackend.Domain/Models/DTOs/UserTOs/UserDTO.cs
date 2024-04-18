using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Models.DTOs.UserTOs
{
    public class UserDTO
    {
        public string Id { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Matricula { get; set; } = null!;
        public string Contato { get; set; } = null!;
        public byte[]? Foto { get; set; }

        public UserDTO CreateModel(User user)
        {
            var userModel = new UserDTO()
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email,
                Matricula = user.Matricula,
                Contato = user.Contato,
                Foto = user.Foto,
            };
            return userModel;
        }
    }
}
