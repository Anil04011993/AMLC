using AMLRS.Core.Abstraction.Reposotory;
using AMLRS.Core.Domains.EntityProfiles.Entities;
using AMLRS.Infrastructure.Data;

namespace AMLRS.Infrastructure.Repositories
{
    public class EntityRepository : Repository<EntityProfile, string>, IEntityRepository
    {
        private readonly AmlDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public EntityRepository(AmlDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
    }
}
