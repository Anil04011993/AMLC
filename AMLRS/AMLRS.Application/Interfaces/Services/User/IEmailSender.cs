using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.Interfaces.Services.User
{
    public interface IEmailSender
    {
        Task SendAsync(string to, string subject, string body);
    }

}
