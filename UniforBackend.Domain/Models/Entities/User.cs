using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.Entities
{
    public class User
    {
        [Key]
        public string Id { get; set; } = null!;
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Matricula { get; set; }
        public byte[]? Foto { get; set; }

        // 1/n com itens
    }
}
