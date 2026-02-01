using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using AMLRS.Application.Interfaces.Services.User;

namespace AMLRS.Application.Services
{
    public class GmailEmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public GmailEmailSender(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendAsync(string to, string subject, string body)
        {
            var message = new MailMessage
            {
                From = new MailAddress(_config["Gmail:FromEmail"]),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            message.To.Add(to);

            using var client = new SmtpClient(
                _config["Gmail:Host"],
                int.Parse(_config["Gmail:Port"]))
            {
                Credentials = new NetworkCredential(
                    _config["Gmail:Username"],
                    _config["Gmail:AppPassword"]),
                EnableSsl = true
            };

            await client.SendMailAsync(message);
        }
    }

}
