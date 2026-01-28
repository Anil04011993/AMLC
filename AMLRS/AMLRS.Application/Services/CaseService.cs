using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services;
using AMLRS.Core.Abstraction.Reposotory;
using AMLRS.Core.Domains.Cases.Enums;
using AMLRS.Core.QueryModels;
using Microsoft.Extensions.Logging;

namespace AMLRS.Application.Services
{
    public class CaseService : ICaseService
    {
        private readonly ICaseRepository _caseRepository;
        private readonly ILogger<CaseService> _logger;

        public CaseService(
            ICaseRepository caseRepository,
            ILogger<CaseService> logger)
        {
            _caseRepository = caseRepository;
            _logger = logger;
        }

        public async Task<IReadOnlyList<EntityDataDto>> GetAllCasesAsync(CaseQueryParams query)
        {
            _logger.LogInformation(
                "Fetching cases. Page={Page}, Size={Size}",
                query.PageNumber,
                query.PageSize);

            if (query.PageNumber <= 0)
            {
                throw new ArgumentException("PageNumber must be greater than zero.");
            }

            var entities = await _caseRepository.GetEntitiesWithCasesAsync(query);

            _logger.LogDebug(
                "Fetched {EntityCount} entities",
                entities.Count);

            var result = entities.Select(entity =>
            {
                var masterCase = entity.Cases
                    .OrderByDescending(c => c.CreatedAt)
                    .FirstOrDefault();

                return new EntityDataDto
                {
                    MasterCaseId = masterCase?.CaseId,
                    EntityId = entity.EntityId,
                    EntityName = entity.EntityName,

                    Tier = masterCase?.Tier?.ToString(),
                    Stage = masterCase?.Stage?.ToString(),
                    OverallStatus = masterCase?.Status.ToString(),

                    IsOverdue = masterCase != null &&
                                masterCase.DueDate < DateTime.UtcNow &&
                                masterCase.Status != CaseStatus.Approved,

                    Owner = masterCase?.Owner,

                    Workstreams = masterCase?.Workstreams
                        .Select(ws => new WorkstreamDto
                        {
                            Type = ws.Type.ToString(),
                            CaseId = ws.CaseId,
                            Status = ws.Status.ToString()
                        })
                        .ToList() ?? new List<WorkstreamDto>()
                };
            }).ToList();

            return result;
        }
    }


}
