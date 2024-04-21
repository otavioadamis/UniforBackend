using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using UniforBackend.Domain.Interfaces.IServices;

namespace UniforBackend.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public EmailService(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public async Task SendEmailAsync(string userEmail, string body)
        {
            var emailSettings = _configuration.GetSection("EmailSettings");

            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_configuration.GetSection("EmailSettings:Email").Value);
            email.Subject = "A deadline is coming!";

            using var smtp = new SmtpClient();
            smtp.Connect(emailSettings["Host"], int.Parse(emailSettings["Port"]), SecureSocketOptions.StartTls);
            smtp.Authenticate(emailSettings["Email"], emailSettings["Password"]);

            email.To.Add(MailboxAddress.Parse(userEmail));

            var builder = new BodyBuilder();
            builder.HtmlBody = body;

            email.Body = builder.ToMessageBody();
            await smtp.SendAsync(email);
            
            smtp.Disconnect(true);
        }
    }
}
