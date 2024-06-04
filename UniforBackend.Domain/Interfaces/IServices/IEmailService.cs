using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Interfaces.IServices
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string userEmail, string body, string subject);
    }
}
