using AMLRS.Application.DTOs;

namespace AMLRS.Application.Interfaces.Services.User
{
    public interface ISignupService
    {
       
        Task<RegisterResponseDto> RegisterAsync(string token);
        Task<bool> SetPasswod(string token, string password);
        Task<TokenValidationResult> ValidateTokenAsync(string token);
        Task<bool> VerifyOtpAsync(
            string email,
            string otp
            //string role,
            //string organisation
            );
    }

}
