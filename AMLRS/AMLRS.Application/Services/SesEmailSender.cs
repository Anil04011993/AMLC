using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using AMLRS.Application.Interfaces.Services;
using Microsoft.Extensions.Configuration;

namespace AMLRS.Application.Services
{
    public class SesEmailSender //: IEmailSender
    {
        private readonly IAmazonSimpleEmailService _ses;
        private readonly string _from;

        public SesEmailSender(
            IAmazonSimpleEmailService ses,
            IConfiguration config)
        {
            _ses = ses;
            _from = config["AwsSes:FromEmail"];
        }

        public async Task SendAsync(string to, string subject, string body)
        {
            var request = new SendEmailRequest
            {
                Source = _from,
                Destination = new Destination { ToAddresses = new List<string> { to } },
                Message = new Message
                {
                    Subject = new Content(subject),
                    Body = new Body
                    {
                        Html = new Content(body)
                    }
                }
            };

            await _ses.SendEmailAsync(request);
        }
    }

}
