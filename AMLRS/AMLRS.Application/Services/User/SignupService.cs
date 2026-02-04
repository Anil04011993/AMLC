using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services.User;
using AMLRS.Core.Abstraction.Reposotory.User;
using AMLRS.Core.Domains.Users.Entities;
using AMLRS.Core.Domains.Users.Entities.Register;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Xml.Linq;

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

        public async Task<RegisterResponseDto> RegisterAsync(string token)
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
                    Email = invite.Email,
                    OtpHash = otp,
                    //OtpHash = BCrypt.Net.BCrypt.HashPassword(otp),
                    ExpiresAt = DateTime.UtcNow.AddMinutes(5),
                    IsUsed = false,
                    CreatedAt = DateTime.UtcNow
                };

                await _otpRepo.AddAsync(otpEntity);

                await _email.SendAsync(
                    invite.Email,
                    "Register One Time Password",
                    $"""
                Dear User,
                Your OTP is <b>{otp}</b>.
                This OTP expires in 5 minutes.
                Do NOT share this OTP with anyone.
                """
                );

                return new RegisterResponseDto { Email = invite.Email };
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

            var org = await _orgRepo.GetByIdAsync(invite.OrgId);
            if (org == null)
                return new TokenValidationResult
                {
                    IsValid = false,
                    Message = "Organisation not found."
                };

            return new TokenValidationResult
            {
                IsValid = true,
                Message = "Valid link",
                CreatedUserOnToken = new CreatedUserOnToken
                {
                    OrgName = org.OrgLegalName,
                    UserName = invite.UserName,
                    Email = invite.Email,
                    Role = invite.Role,
                }
            };
        }


        public async Task<bool> VerifyOtpAndCreateUserAsync(
            string email,
            string otp)
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

            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        public async Task<bool> SetPasswod(string token, string password)
        {
            try
            {
                var invite = await _inviteRepo.GetByTokenAsync(token);

                if (invite == null) throw new Exception();

                var user = new Usertbl
                {
                    UserName = invite.UserName,
                    OrgId = invite.OrgId,
                    Email = invite.Email,
                    Password = password,
                    IsActive = true,
                    Role = invite.Role,
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
