using AMLRS.Core.Abstraction.Reposotory;
using AMLRS.Core.Abstraction.Reposotory.User;
using AMLRS.Core.Domains.OrganisationAdmins.Entites;
using AMLRS.Core.Domains.Users.Entities;
using AMLRS.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AMLRS.Infrastructure.Repositories.User
{
    public class UserRepository : Repository<Usertbl, int>, IUserRepository
    {
        private readonly AmlDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public UserRepository(AmlDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
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
                UserName = user.UserName,
                Email = user.Email,
                //Gender = Core.Domains.Users.Enums.Gender.Male,
                Role = role.RoleName,
            };
        }

        public async Task<Usertbl?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Role?> GetRolesByUserIdAsync(int userId)
        {
            return await _context.UserRoleAssignments
                .Where(x => x.UserId == userId)
                .Select(x => x.Role)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        public IQueryable<UserWithOrgName> GetUsersWithOrgNameQueryable()
        {
            return from u in _context.Users
                   join o in _context.Organisations
                       on u.OrgId equals o.OrgId
                   orderby u.UserId descending
                   select new UserWithOrgName
                   {
                       User = u,
                       OrgName = o.OrgLegalName
                   };
        }
    }
}
