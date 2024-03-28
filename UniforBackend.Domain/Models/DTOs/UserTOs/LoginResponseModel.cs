using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.DTOs.UserTOs
{
    public class LoginResponseModel
    {
        public required string Token { get; set; }
        public required UserDTO User { get; set; }
    }
}
