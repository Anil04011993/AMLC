using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services.User;
using AMLRS.Core.Abstraction.Reposotory.User;
using AMLRS.Core.Domains.Admin.Entites;
using AMLRS.Core.Domains.Admin.Entities;

namespace AMLRS.Application.Services.User
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IOrganisationRepository _orgRepository;

        public AdminService(IAdminRepository adminRepository, IOrganisationRepository orgRepository)
        {
            _adminRepository = adminRepository;
            _orgRepository = orgRepository;
        }

        // ------------------- Admin -------------------

        public async Task<IEnumerable<AdminDto>> GetAllAdminsAsync()
        {
            var admins = await _adminRepository.GetAllAsync();
            return admins.Select(a => new AdminDto
            {
                AdminId = a.AdminId,
                OrgId = a.OrgId,
                Name = a.Name,
                EmailId = a.EmailId,
                Role = a.Role
            });
        }

        public async Task<AdminDto?> GetAdminByIdAsync(int adminId)
        {
            var admin = await _adminRepository.GetByIdAsync(adminId);
            if (admin == null) return null;

            return new AdminDto
            {
                AdminId = admin.AdminId,
                OrgId = admin.OrgId,
                Name = admin.Name,
                EmailId = admin.EmailId,
                Role = admin.Role
            };
        }

        public async Task<AdminDto> AddAdminAsync(AdminDto adminDto)
        {
            var admin = new OrgAdmin
            {                
                OrgId = adminDto.OrgId,
                Name = adminDto.Name,
                EmailId = adminDto.EmailId,
                Role = adminDto.Role
            };

            await _adminRepository.AddAsync(admin);

            return new AdminDto
            {
                AdminId = admin.AdminId,
                OrgId = admin.OrgId,
                Name = admin.Name,
                EmailId = admin.EmailId,
                Role = admin.Role
            };
        }

        // ------------------- Organisation -------------------

        public async Task<IEnumerable<OrganisationDto>> GetAllOrganisationsAsync()
        {
            var organisations = await _orgRepository.GetAllAsync();

            return organisations.Select(o => new OrganisationDto
            {
                OrgId = o.OrgId,
                OrgLegalName = o.OrgLegalName,
                DateOfCreation = o.DateOfCreation,
                PrimaryContactName = o.PrimaryContactName,
                PrimaryContactEmail = o.PrimaryContactEmail
            });
        }

        public async Task<OrganisationDto?> GetOrganisationByIdAsync(int orgId)
        {
            var org = await _orgRepository.GetByIdAsync(orgId);
            if (org == null) return null;

            return new OrganisationDto
            {
                OrgId = org.OrgId,
                OrgLegalName = org.OrgLegalName,
                DateOfCreation = org.DateOfCreation,
                PrimaryContactName = org.PrimaryContactName,
                PrimaryContactEmail = org.PrimaryContactEmail
            };
        }

        public async Task<OrganisationDto> AddOrganisationAsync(OrganisationDto organisationDto)
        {
            var organisation = new Organisation
            {
                OrgLegalName = organisationDto.OrgLegalName,
                DateOfCreation = DateTime.UtcNow,
                PrimaryContactName = organisationDto.PrimaryContactName,
                PrimaryContactEmail = organisationDto.PrimaryContactEmail,
                BrandName = organisationDto.BrandName,
                CountryOfCorp = organisationDto.CountryOfCorp,
                EntityType = organisationDto.EntityType,
                PrimaryContactPhone = organisationDto.PrimaryContactPhone,
                PrimaryOperatingCountries = organisationDto.PrimaryOperatingCountries,
                RegistrationNumber = organisationDto.RegistrationNumber,
                Regulator_LicenseNumber = organisationDto.RegistrationNumber,
                TaxIdentificatioNumber = organisationDto.TaxIdentificatioNumber,
                SupportEmail = organisationDto.SupportEmail,
            };

            await _orgRepository.AddAsync(organisation);

            return new OrganisationDto
            {
                OrgId = organisation.OrgId,
                OrgLegalName = organisation.OrgLegalName,
                DateOfCreation = organisation.DateOfCreation,
                PrimaryContactName = organisation.PrimaryContactName,
                PrimaryContactEmail = organisation.PrimaryContactEmail
            };
        }
    }
}
