using AMLRS.Application.DTOs;

namespace AMLRS.Application.Interfaces.Services.User
{
    public interface IOrganisationService
    {     
        Task<IEnumerable<OrganisationDto>> GetAllOrganisationsAsync();
        Task<OrganisationDto?> GetOrganisationByIdAsync(int orgId);
        Task<OrganisationDto> AddOrganisationAsync(OrganisationDto organisationDto);
        Task<OrganisationDto> UpdateOrgAsync(int id, OrganisationDto orgDto);
        Task<bool> DeleteOrgAsync(int id);
    }
}
