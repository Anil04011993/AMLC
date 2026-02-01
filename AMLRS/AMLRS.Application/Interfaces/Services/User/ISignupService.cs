namespace AMLRS.Application.Interfaces.Services.User
{
    public interface ISignupService
    {
        Task RegisterAsync(string token, string email);
        Task<bool> VerifyOtpAndCreateUserAsync(string email, string otp, string password);
    }

}
