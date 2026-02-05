using AMLRS.Core.Domains.OrganisationAdmins.Entites;
using AMLRS.Infrastructure.Data;

namespace AMLRS.Core.Abstraction.Reposotory.User
{
    public interface IOrganisationRepository : IRepository<Organisation, int>
    {
        Task<Organisation?> GetOrganisationByOrgNameAsync(string name);
        IQueryable<Organisation?> GetAllOrganisationQueryable();

    }
}
