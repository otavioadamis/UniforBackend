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

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string userEmail, string body, string subject)
        {
            var emailSettings = _configuration.GetSection("EmailSettings");

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(emailSettings["Displayname"], emailSettings["Email"]));
            email.Subject = subject;

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
