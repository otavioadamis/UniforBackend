using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniforBackend.Domain.Models.enums;

namespace UniforBackend.Domain.Models.Entities
{
    public class User
    {
        [Key]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; } = null!;
        
        [Column(TypeName = "varchar(60)")]
        public required string Nome { get; set; }

        [Column(TypeName = "varchar(255)")]
        public required string Email { get; set; }
        
        [Column(TypeName = "varchar(10)")]
        public required string Matricula { get; set; }
        
        [Column(TypeName = "varchar(255)")]
        public required string Password { get; set; }    
        public byte[]? Foto { get; set; }
        public Role Tipo { get; set; } 

        
        //EF Core mapping
        public ICollection<Item>? Itens { get; set; }
    }
}
