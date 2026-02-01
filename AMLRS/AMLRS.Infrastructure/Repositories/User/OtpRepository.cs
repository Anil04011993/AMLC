using AMLRS.Core.Abstraction.Reposotory.User;
using AMLRS.Core.Domains.Users.Entities.Register;
using AMLRS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AMLRS.Infrastructure.Repositories.User
{
    public class OtpRepository : IOtpRepository
    {
        private readonly AmlDbContext _db;

        public OtpRepository(AmlDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(EmailOtp otp)
        {
            _db.EmailOtps.Add(otp);
            await _db.SaveChangesAsync();
        }

        public async Task<EmailOtp?> GetActiveOtpAsync(string email)
        {
            return await _db.EmailOtps
                .Where(x =>
                    x.Email == email &&
                    x.ExpiresAt > DateTime.UtcNow)
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync();
        }

        public async Task MarkUsedAsync(EmailOtp otp)
        {
            otp.IsUsed = true;
            await _db.SaveChangesAsync();
        }
    }
}
