using AMLRS.Application.DTOs;
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
        private readonly IOrganisationRepository _orgRepo;
        private readonly IOtpRepository _otpRepo;
        private readonly IEmailSender _email;

        public SignupService(
            IUserInviteRepository inviteRepo,
            IUserRepository userRepo,
            IOrganisationRepository orgRepo,
            IOtpRepository otpRepo,
            IEmailSender email)
        {
            _inviteRepo = inviteRepo;
            _userRepo = userRepo;
            _orgRepo = orgRepo;
            _otpRepo = otpRepo;
            _email = email;
        }

        public async Task RegisterAsync(string token, string email)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TokenValidationResult> ValidateTokenAsync(string token)
        {
            var invite = await _inviteRepo.GetByTokenAsync(token);

            if (invite == null || invite.IsUsed)
            {
                return new TokenValidationResult
                {
                    IsValid = false,
                    Message = "Invalid link. Please request a new one."
                };
            }

            if (invite.ExpiresAt < DateTime.UtcNow)
            {
                return new TokenValidationResult
                {
                    IsValid = false,
                    Message = "The link has expired. Please request a new one"
                };
            }

            return new TokenValidationResult
            {
                IsValid = true,
                Message = "Valid link"
            };
        }


        public async Task<bool> VerifyOtpAndCreateUserAsync(
            string name,
            string email,
            string otp,
            string password)
        {
            try
            {
                var otpEntity = await _otpRepo.GetActiveOtpAsync(email);
                if (otpEntity == null)
                    throw new Exception("OtpEntity not found");
                var inviteEntity = await _inviteRepo.GetByEmailAsync(email);
                if (inviteEntity == null)
                    throw new Exception("InviteEntity not found");

                //if (otpEntity == null ||
                //    otpEntity.ExpiresAt < DateTime.UtcNow ||
                //    !BCrypt.Net.BCrypt.Verify(otp, otpEntity.OtpHash))
                if (otpEntity == null || string.IsNullOrEmpty(otp))
                    throw new Exception("Invalid or expired OTP");

                if (otpEntity.OtpHash != otp)
                    throw new Exception("Invalid OTP");

                otpEntity.IsUsed = true;
                await _otpRepo.MarkUsedAsync(otpEntity);

                //get org details
                //var org = await _orgRepo.GetByIdAsync(inviteEntity.OrgId);
                //if (org == null)
                //    throw new Exception($"Organisation does not exist.");
                //role from payload?

                var user = new Usertbl
                {
                    PreferredName = name,
                    OrgId = 5,//org.OrgId,
                    Email = email,
                    Password = password,
                    IsActive = true,
                    Role = inviteEntity.Role,
                    CreatedAt = DateTime.UtcNow
                };

                await _userRepo.AddAsync(user);
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
    }

}
