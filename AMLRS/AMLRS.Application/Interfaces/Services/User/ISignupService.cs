using AMLRS.Application.DTOs;

namespace AMLRS.Application.Interfaces.Services.User
{
    public interface ISignupService
    {
        Task RegisterAsync(string token, string email);
        Task<TokenValidationResult> ValidateTokenAsync(string token);
        Task<bool> VerifyOtpAndCreateUserAsync(
            string name,
            string email,
            string otp,
            string password
            //string role,
            //string organisation
            );
    }

}
