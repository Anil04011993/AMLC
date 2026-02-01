using AMLRS.Core.Abstraction.Reposotory;
using AMLRS.Core.Abstraction.Reposotory.User;
using AMLRS.Core.Domains.Admin.Entities;
using AMLRS.Infrastructure.Data;

namespace AMLRS.Infrastructure.Repositories.User
{
    public class AdminRepository : Repository<OrgAdmin, int>, IAdminRepository   // <-- implement interface
    {
        private readonly AmlDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public AdminRepository(AmlDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        //private readonly AmlDbContext _context;

        //public AdminRepository(AmlDbContext context)
        //{
        //    _context = context;
        //}

        //public async Task<IEnumerable<OrgAdmin>> GetAllAdminsAsync()
        //{
        //    return await _context.Admins.Include(a => a.Org).ToListAsync();
        //}

        //public async Task<OrgAdmin?> GetAdminByIdAsync(int adminId)
        //{
        //    return await _context.Admins.Include(a => a.Org)
        //                                .FirstOrDefaultAsync(a => a.AdminId == adminId);
        //}

        //public async Task<OrgAdmin> AddAdminAsync(OrgAdmin admin)
        //{
        //    _context.Admins.Add(admin);
        //    await _context.SaveChangesAsync();
        //    return admin;
        //}

        //public async Task<IEnumerable<Organisation>> GetAllOrganisationsAsync()
        //{
        //    return await _context.Organisations.ToListAsync();
        //}


        //public async Task<Organisation?> GetOrganisationByIdAsync(int orgId)
        //{
        //    return await _context.Organisations.FirstOrDefaultAsync(o => o.OrgId == orgId);
        //}

        //public async Task<Organisation> AddOrganisationAsync(Organisation organisation)
        //{
        //    _context.Organisations.Add(organisation);
        //    await _context.SaveChangesAsync();
        //    return organisation;
        //}
    }
}
