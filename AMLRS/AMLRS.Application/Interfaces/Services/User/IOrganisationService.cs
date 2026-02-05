using AMLRS.Application.DTOs;
using AMLRS.Core.QueryModels;

namespace AMLRS.Application.Interfaces.Services.User
{
    public interface IOrganisationService
    {
        Task<PagedResult<OrganisationResponseDto>> GetAllOrganisationsAsync(OrgQueryParams queryParams);
        Task<OrganisationResponseDto?> GetOrganisationByIdAsync(int orgId);
        Task<OrganisationResponseDto> AddOrganisationAsync(OrganisationDto organisationDto);
        Task<OrganisationDto> UpdateOrgAsync(int id, OrganisationDto orgDto);
        Task<bool> DeleteOrgAsync(int id);
    }
}
