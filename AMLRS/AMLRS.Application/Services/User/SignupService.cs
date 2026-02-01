using AMLRS.Application.Interfaces.Services.User;
using AMLRS.Core.Abstraction.Reposotory.User;
using AMLRS.Core.Domains.Users.Entities;
using AMLRS.Core.Domains.Users.Entities.Register;
using System.Security.Cryptography;

namespace AMLRS.Application.Services.User
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

        public async Task RegisterAsync(string token, string email)
        {
            var invite = await _inviteRepo.GetByTokenAsync(token);

            if (invite == null || invite.IsUsed)
                throw new Exception("Invalid invite");

            if (invite.ExpiresAt < DateTime.UtcNow)
                throw new Exception("Link expired");

            // Generate OTP
            var otp = RandomNumberGenerator.GetInt32(100000, 999999).ToString();

            var otpEntity = new EmailOtp
            {
                Email = email,
                OtpHash = otp,
                //OtpHash = BCrypt.Net.BCrypt.HashPassword(otp),
                ExpiresAt = DateTime.UtcNow.AddMinutes(5),
                IsUsed = false,
                CreatedAt = DateTime.UtcNow
            };

            await _otpRepo.AddAsync(otpEntity);

            await _email.SendAsync(
                email,
                "Register One Time Password",
                $"""
                Dear User,
                Your OTP is <b>{otp}</b>.
                This OTP expires in 5 minutes.
                Do NOT share this OTP with anyone.
                """
            );
        }

        public async Task<bool> VerifyOtpAndCreateUserAsync(
            string email,
            string otp,
            string password)
        {
            var otpEntity = await _otpRepo.GetActiveOtpAsync(email);

            //if (otpEntity == null ||
            //    otpEntity.ExpiresAt < DateTime.UtcNow ||
            //    !BCrypt.Net.BCrypt.Verify(otp, otpEntity.OtpHash))
            if (otpEntity == null || string.IsNullOrEmpty(otp))
                throw new Exception("Invalid or expired OTP");

            otpEntity.IsUsed = true;
            await _otpRepo.MarkUsedAsync(otpEntity);

            var user = new Usertbl
            {
                Email = email,
                Password = password,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepo.AddAsync(user);
            return true;
        }

    }

}
