using AMLRS.Core.Abstraction.Reposotory;
using AMLRS.Core.Domains.Users.Entities.Register;
using AMLRS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AMLRS.Infrastructure.Repositories
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

        public async Task<EmailOtp?> GetValidOtpAsync(int userId)
        {
            return await _db.EmailOtps
                .Where(x =>
                    x.UserId == userId &&
                    !x.IsUsed &&
                    x.ExpiresAt > DateTime.Now)
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
