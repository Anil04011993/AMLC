using AMLRS.Core.Abstraction.Repository;
using AMLRS.Core.Domains.Admin.Entites;
using AMLRS.Core.Domains.Admin.Entities;
using AMLRS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AMLRS.Infrastructure.Repositories
{
    public class AdminRepository : IAdminRepository   // <-- implement interface
    {
        private readonly AmlDbContext _context;

        public AdminRepository(AmlDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrgAdmin>> GetAllAdminsAsync()
        {
            return await _context.Admins.Include(a => a.Org).ToListAsync();
        }

        public async Task<OrgAdmin?> GetAdminByIdAsync(Guid adminId)
        {
            return await _context.Admins.Include(a => a.Org)
                                        .FirstOrDefaultAsync(a => a.AdminId == adminId);
        }

        public async Task<OrgAdmin> AddAdminAsync(OrgAdmin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        public async Task<IEnumerable<Organisation>> GetAllOrganisationsAsync()
        {
            return await _context.Organisations.ToListAsync();
        }


        public async Task<Organisation?> GetOrganisationByIdAsync(Guid orgId)
        {
            return await _context.Organisations.FirstOrDefaultAsync(o => o.OrgId == orgId);
        }

        public async Task<Organisation> AddOrganisationAsync(Organisation organisation)
        {
            _context.Organisations.Add(organisation);
            await _context.SaveChangesAsync();
            return organisation;
        }
    }
}
