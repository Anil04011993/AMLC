using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services;
using AMLRS.Core.Abstraction.Reposotory;
using AMLRS.Core.Domains.Users.Entities;
using Microsoft.Extensions.Configuration;

namespace AMLRS.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<User?> LoginAsync(UserLoginRequestDto login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
            {
                return null;
            }

            var user = await _userRepository.LoginAsync(login.Email, login.Password);
            if (user == null) return null;

            // No token generation — simple login returning user details
            return user;
        }
    }
}
