using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.Interfaces.Services
{
    public interface ISignupService
    {
        Task RegisterAsync(string token, string email, string password);
        Task VerifyOtpAsync(string email, string otp);
    }

}
