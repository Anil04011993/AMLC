using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AMLRS.Core.Abstraction.Reposotory;
using AMLRS.Core.Domains.Admin.Entites;
using AMLRS.Core.Domains.Admin.Entities;

namespace AMLRS.Core.Abstraction.Reposotory.User
{
    public interface IAdminRepository : IRepository<OrgAdmin, int>
    {        
        
    }
}
