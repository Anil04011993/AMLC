using AMLRS.Core.Abstraction.Reposotory.User;
using AMLRS.Core.Domains.Users.Entities.Register;
using AMLRS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AMLRS.Infrastructure.Repositories.User
{
    public class UserInviteRepository : IUserInviteRepository
    {
        private readonly AmlDbContext _db;

        public UserInviteRepository(AmlDbContext db)
        {
            _db = db;
        }

        public async Task<UserInvite?> GetByTokenAsync(string token)
        {
            return await _db.UserInvites
                .FirstOrDefaultAsync(x => x.InviteToken == token);
        }

        public async Task<UserInvite?> GetByEmailAsync(string email)
        {
            return await _db.UserInvites
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task AddAsync(UserInvite invite)
        {
            _db.UserInvites.Add(invite);
            await _db.SaveChangesAsync();
        }

        public async Task MarkUsedAsync(UserInvite invite)
        {
            invite.IsUsed = true;
            await _db.SaveChangesAsync();
        }
    }
}
