using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.DTOs
{
    public class PostUserDTO
    {
        [Required]
        public required string Nome { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Matricula { get; set; }

        public byte[]? Foto { get; set; }
    }
}
