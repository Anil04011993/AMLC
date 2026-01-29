using AMLRS.Core.Abstraction.Reposotory;
using AMLRS.Core.Domains.Users.Entities;
using AMLRS.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AMLRS.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AmlDbContext _context;

        public UserRepository(AmlDbContext db)
        {
            _context = db;
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            var user = await _context.Users
                .AsNoTracking()
                .Where(u => u.Email == email && u.Password == password)
               .FirstOrDefaultAsync();

            if (user == null || string.IsNullOrEmpty(user.Password))
                return null;

            var hasher = new PasswordHasher<object>();
            var verify = hasher.VerifyHashedPassword(null, user.Password, password);
            if (verify == PasswordVerificationResult.Failed)
                return null;

            return new User
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                PreferredName = user.PreferredName,
                Password = user.Password,
                Gender = Core.Domains.Users.Enums.Gender.Male
            };
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
