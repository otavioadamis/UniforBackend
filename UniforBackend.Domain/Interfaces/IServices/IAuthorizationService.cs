using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Interfaces.IServices
{
    public interface IAuthorizationService
    {
        public string CreateToken(User thisUser);
        public string? ValidateJwtToken(string token);
        public bool ValidarEmail(string userId, string codigoVerificacao);
    }
}
