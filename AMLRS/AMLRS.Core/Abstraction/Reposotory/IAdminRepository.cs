using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AMLRS.Core.Domains.Admin.Entites;
using AMLRS.Core.Domains.Admin.Entities;

namespace AMLRS.Core.Abstraction.Repository
{
    public interface IAdminRepository
    {        
        Task<IEnumerable<OrgAdmin>> GetAllAdminsAsync();        
        Task<OrgAdmin?> GetAdminByIdAsync(int adminId);        
        Task<OrgAdmin> AddAdminAsync(OrgAdmin admin);        
        Task<IEnumerable<Organisation>> GetAllOrganisationsAsync();        
        Task<Organisation?> GetOrganisationByIdAsync(int orgId);        
        Task<Organisation> AddOrganisationAsync(Organisation organisation);
    }
}
