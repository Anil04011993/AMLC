using AMLRS.Application.DTOs;

namespace AMLRS.Application.Interfaces.Services.User
{
    public interface IAdminService
    {
        // ------------------- Admin -------------------

        Task<IEnumerable<AdminDto>> GetAllAdminsAsync();
        Task<AdminDto?> GetAdminByIdAsync(int adminId);
        Task<AdminDto> AddAdminAsync(AdminDto adminDto);

        // ------------------- Organisation -------------------

        Task<IEnumerable<OrganisationDto>> GetAllOrganisationsAsync();
        Task<OrganisationDto?> GetOrganisationByIdAsync(int orgId);
        Task<OrganisationDto> AddOrganisationAsync(OrganisationDto organisationDto);
    }
}
