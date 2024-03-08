using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.Entities
{
    public class Carrinho
    {
        //Relacao de 1 pra 1, o Id do carrinho é o próprio Id do usuário.
     
        //Mapeação Entity Framework (1 pra 1)
        public User User { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }
}


//todo -> n/n com itens
// 1/1 com user
