using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Models.DTOs
{
    public class UpdateUserDTO
    {
        [Required]
        public required string Nome { get; set; }

        [Required]
        public required string Email { get; set; }

        public byte[]? Foto { get; set; }

        public void UpdateFields(User user)
        {
            user.Nome = Nome;
            user.Email = Email;
            user.Foto = Foto;
        }
    }
}
