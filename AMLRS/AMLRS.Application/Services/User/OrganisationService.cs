using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services.User;
using AMLRS.Core.Abstraction.Reposotory.User;
using AMLRS.Core.Domains.OrganisationAdmins.Entites;

namespace AMLRS.Application.Services.User
{
    public class OrganisationService : IOrganisationService
    {
        private readonly IOrganisationRepository _orgRepository;

        public OrganisationService(IOrganisationRepository orgRepository)
        {
            _orgRepository = orgRepository;
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

        public async Task<OrganisationDto?> UpdateOrgAsync(int id, OrganisationDto orgDto)
        {
            var org = await _orgRepository.GetOrganisationByOrgNameAsync(orgDto.OrgLegalName);
            if (org == null)
                throw new Exception($"{orgDto.OrgLegalName} does not exist.");

            var OrgEntity = new Organisation
            {
                OrgLegalName = orgDto.OrgLegalName,
                PrimaryContactEmail = orgDto.PrimaryContactEmail,

                OrgId = orgDto.OrgId
            };

            await _orgRepository.UpdateAsync(OrgEntity);
            return orgDto;
        }

        public async Task<bool> DeleteOrgAsync(int id)
        {
            var org = await _orgRepository.GetByIdAsync(id);

            if (org == null)
                throw new Exception($"admin does not exist.");

            await _orgRepository.DeleteAsync(org);
            return true;
        }
    }
}
