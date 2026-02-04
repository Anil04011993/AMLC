using AMLRS.Application.DTOs;

namespace AMLRS.Application.Interfaces.Services.User
{
    public interface IOrganisationService
    {     
        Task<IEnumerable<OrganisationResponseDto>> GetAllOrganisationsAsync();
        Task<OrganisationResponseDto?> GetOrganisationByIdAsync(int orgId);
        Task<OrganisationResponseDto> AddOrganisationAsync(OrganisationDto organisationDto);
        Task<OrganisationDto> UpdateOrgAsync(int id, OrganisationDto orgDto);
        Task<bool> DeleteOrgAsync(int id);
    }
}
