using AMLRS.Application.DTOs;

namespace AMLRS.Application.Interfaces.Services.User
{
    public interface ISignupService
    {
        Task RegisterAsync(string token, string email);
        Task<bool> SetPasswod(string email, string password);
        Task<TokenValidationResult> ValidateTokenAsync(string token);
        Task<bool> VerifyOtpAndCreateUserAsync(
            string email,
            string otp
            //string role,
            //string organisation
            );
    }

}
