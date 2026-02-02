using AMLRS.Core.Abstraction.Reposotory;
using AMLRS.Core.Abstraction.Reposotory.User;
using AMLRS.Core.Domains.OrganisationAdmins.Entites;
using AMLRS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AMLRS.Infrastructure.Repositories.User
{
    public class OrganisationRepository : Repository<Organisation, int>, IOrganisationRepository
    {
        private readonly AmlDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public OrganisationRepository(AmlDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Organisation?> GetOrganisationByOrgNameAsync(string name)
        {
            return await _context.Organisations
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.OrgLegalName == name);
        }

        public async Task<Organisation?> GetOrganisationByOrgidAsync(int id)
        {
            return await _context.Organisations
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.OrgId == id);
        }
    }
}
