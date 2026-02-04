using AMLRS.Core.Domains.OrganisationAdmins.Entites;

namespace AMLRS.Core.Abstraction.Reposotory.User
{
    public interface IOrganisationRepository : IRepository<Organisation, int>
    {
        Task<Organisation?> GetOrganisationByOrgNameAsync(string name);
    }
}
