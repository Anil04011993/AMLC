using AMLRS.Application.Abstraction;
using AMLRS.Application.DTOs;
using AMLRS.Core.Domains.Users.Entities;
using AMLRS.Infrastructure.Data;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace AMLRS.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AmlDbContext _context;

        public UserRepository(AmlDbContext context)
        {
            _context = context;
        }

        public async Task<UserResponseDto?> LoginAsync(UserLoginRequestDto login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
                return null;

            var user = await _context.Users
                .AsNoTracking()
                .Where(u => u.Email == login.Email)
                .Select(u => new
                {
                    u.UserId,
                    u.FirstName,
                    u.LastName,
                    u.Email,
                    u.PhoneNumber,
                    u.PreferredName,
                    u.Auth_and_Security.PasswordHash 

                })
                .FirstOrDefaultAsync();

            if (user == null || string.IsNullOrEmpty(user.PasswordHash) )

                return null;

            var hasher= new PasswordHasher<object>();
            var verify= hasher.VerifyHashedPassword(null, user.PasswordHash, login.Password);
            if (verify == PasswordVerificationResult.Failed)
                return null;

          

            return new UserResponseDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                PreferredName = user.PreferredName
            };
        }
    }
}
