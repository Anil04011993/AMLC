using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services;
using AMLRS.Core.Abstraction.Reposotory;
using AMLRS.Core.Domains.Users.Entities;
using AMLRS.Core.Domains.Users.Entities.Register;
using Microsoft.Extensions.Configuration;

namespace AMLRS.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOtpRepository _otpRepo;
        private readonly IEmailSender _email;

        public UserService(IUserRepository userRepository, IOtpRepository otpRepo, IEmailSender email)
        {
            _userRepository = userRepository;
            _otpRepo = otpRepo;
            _email = email;
        }

        public async Task<LoggedInUserDto?> LoginAsync(UserLoginRequestDto login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
            {
                return null;
            }

            var user = await _userRepository.LoginAsync(login.Email, login.Password);
            if (user == null) return null;
            /*
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
                login.Email,
                "Login One Time Password",
                $"""
                Dear User,
                Your OTP is <b>{otp}
                This Otp expires in 5 mins.
                The Otp is confidential, DO NOT share the Otp with anyone.
                """);
            */
            // No token generation — simple login returning user details
            return new LoggedInUserDto
            {
                UserId = user.UserId,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role.ToString(),
            };
        }
    }
}
