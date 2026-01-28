using AMLRS.Core.Domains.EntityProfiles.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Core.Abstraction.Reposotory
{
    public interface IEntityRepository : IRepository<EntityProfile, string>
    {
    }
}
