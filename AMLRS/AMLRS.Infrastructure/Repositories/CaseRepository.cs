using AMLRS.Core.Abstraction.Reposotory;
using AMLRS.Core.Domains.Cases.Entities;
using AMLRS.Core.Domains.EntityProfiles.Entities;
using AMLRS.Core.QueryModels;
using AMLRS.Infrastructure.Data;
using AMLRS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AMLRS.Infrastructure.Repository
{
    public class CaseRepository : Repository<Case, string>, ICaseRepository
    {
        private readonly AmlDbContext _context;
        private readonly ILogger<CaseRepository> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CaseRepository(AmlDbContext context, ILogger<CaseRepository> logger, IUnitOfWork unitOfWork) : base(context, unitOfWork) 
        {
            _context = context;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<EntityProfile>> GetEntitiesWithCasesAsync(CaseQueryParams query)
        {
            _logger.LogInformation(
                "Fetching entities with cases. Page={Page}, Size={Size}",
                query.PageNumber,
                query.PageSize);

            var res = _context.EntityProfiles
                .Include(e => e.Cases)
                    .ThenInclude(c => c.Workstreams)
                .AsQueryable();

            return await res
                .OrderByDescending(e => e.CreatedAt)
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();
        }
    }

}
