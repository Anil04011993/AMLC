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

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoggedInUserDto?> LoginAsync(UserLoginRequestDto login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
            {
                return null;
            }

            var user = await _userRepository.LoginAsync(login.Email, login.Password);
            if (user == null) return null;

            // No token generation — simple login returning user details
            return new LoggedInUserDto
            {
                UserId = user.UserId,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
    }
}
