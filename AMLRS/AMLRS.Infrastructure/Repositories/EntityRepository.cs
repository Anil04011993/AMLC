using AMLRS.Core.Abstraction.Reposotory;
using AMLRS.Core.Domains.EntityProfiles.Entities;
using AMLRS.Infrastructure.Data;

namespace AMLRS.Infrastructure.Repositories
{
    public class EntityRepository : Repository<EntityProfile, string>, IEntityRepository
    {
        private readonly AmlDbContext _context;
       
        public EntityRepository(AmlDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
