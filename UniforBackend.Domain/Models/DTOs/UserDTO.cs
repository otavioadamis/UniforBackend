using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; } = null!;
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Matricula { get; set; }
        public byte[]? Foto { get; set; }
    }
}
