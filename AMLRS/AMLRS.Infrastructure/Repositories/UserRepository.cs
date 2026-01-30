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

        public async Task<Usertbl?> LoginAsync(string email, string password)
        {
            var user = await GetByEmailAsync(email);

            if (user == null || !string.IsNullOrEmpty(user.Password) && user.Password != password)
                return null;

            var role = await GetRolesByUserIdAsync(user.UserId);
            if (role == null) return null;

            return new Usertbl
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Gender = Core.Domains.Users.Enums.Gender.Male,
                Role = role.RoleName,
            };
        }

        public async Task<Usertbl?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task AddAsync(Usertbl user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<Role?> GetRolesByUserIdAsync(int userId)
        {
            return await _context.UserRoleAssignments
                .Where(x => x.UserId == userId)
                .Select(x => x.Role)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
