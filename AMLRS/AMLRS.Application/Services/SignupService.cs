using AMLRS.Application.Interfaces.Services;
using AMLRS.Core.Abstraction.Reposotory;
using AMLRS.Core.Domains.Users.Entities;
using AMLRS.Core.Domains.Users.Entities.Register;

namespace AMLRS.Application.Services
{
    public class SignupService : ISignupService
    {
        private readonly IUserInviteRepository _inviteRepo;
        private readonly IUserRepository _userRepo;
        private readonly IOtpRepository _otpRepo;
        private readonly IEmailSender _email;

        public SignupService(
            IUserInviteRepository inviteRepo,
            IUserRepository userRepo,
            IOtpRepository otpRepo,
            IEmailSender email)
        {
            _inviteRepo = inviteRepo;
            _userRepo = userRepo;
            _otpRepo = otpRepo;
            _email = email;
        }

        public async Task RegisterAsync(string token, string email, string password)
        {
            var invite = await _inviteRepo.GetByTokenAsync(token);

            if (invite == null || invite.IsUsed)
                throw new Exception("Invalid invite");

            if (invite.ExpiresAt < DateTime.Now)
                throw new Exception("Link expired");

            var user = new User
            {
                UserId = Guid.NewGuid().ToString(),
                FirstName = "John",
                LastName = "Smith",
                Gender = Core.Domains.Users.Enums.Gender.Male,
                PhoneNumber = "82565656464",
                
                Email = email,
                Password = password
            };

            await _userRepo.AddAsync(user);
            await _inviteRepo.MarkUsedAsync(invite);

            var otp = new Random().Next(100000, 999999).ToString();

            var otpEntity = new EmailOtp
            {
                Id = Guid.NewGuid(),
                //UserId = user.Id,
                //OtpHash = BCrypt.Net.BCrypt.HashPassword(otp),
                ExpiresAt = DateTime.UtcNow.AddMinutes(5),
                IsUsed = false
            };

            await _otpRepo.AddAsync(otpEntity);

            await _email.SendAsync(
                email,
                "Verify your email",
                $"Your OTP is <b>{otp}</b>");
        }

        public async Task VerifyOtpAsync(string email, string otp)
        {
            var user = await _userRepo.GetByEmailAsync(email)
                ?? throw new Exception("User not found");

            var record = await _otpRepo.GetValidOtpAsync(user.UserId)
                ?? throw new Exception("OTP expired");

            //if (!BCrypt.Net.BCrypt.Verify(otp, record.OtpHash))
            //    throw new Exception("Invalid OTP");

            //user.IsActive = true;
            //record.IsUsed = true;

            await _otpRepo.MarkUsedAsync(record);
        }
    }

}
