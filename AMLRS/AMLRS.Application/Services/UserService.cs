using AMLRS.Application.Abstraction;
using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services;
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

        public async Task<UserResponseDto?> LoginAsync(UserLoginRequestDto login)
        {
            var user = await _userRepository.LoginAsync(login);
            if (user == null) return null;

            // No token generation — simple login returning user details
            return user;
        }
    }
}
