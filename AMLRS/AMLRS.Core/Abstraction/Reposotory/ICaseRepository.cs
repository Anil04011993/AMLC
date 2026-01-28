using AMLRS.Core.Domains.Cases.Entities;
using AMLRS.Core.Domains.EntityProfiles.Entities;
using AMLRS.Core.QueryModels;

namespace AMLRS.Core.Abstraction.Reposotory
{
    public interface ICaseRepository : IRepository<Case, string>
    {
        Task<List<EntityProfile>> GetEntitiesWithCasesAsync(CaseQueryParams query);
    }
}
