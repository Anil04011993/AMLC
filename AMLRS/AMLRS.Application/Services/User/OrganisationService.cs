using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services.User;
using AMLRS.Core.Abstraction.Reposotory.User;
using AMLRS.Core.Domains.OrganisationAdmins.Entites;
using AMLRS.Core.QueryModels;

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

        public async Task<PagedResult<OrganisationResponseDto>> GetAllOrganisationsAsync(OrgQueryParams queryParams)
        {
        
            var query = _orgRepository.GetAllOrganisationQueryable();

            if (!string.IsNullOrWhiteSpace(queryParams?.SearchText))
            {
                var search = queryParams.SearchText.Trim();

                query = query.Where(o =>
                    o.OrgLegalName.Contains(search) ||
                    o.PrimaryContactName.Contains(search) ||
                    o.PrimaryContactEmail.Contains(search)
                );
            }
            return await query
                .OrderByDescending(o => o.DateOfCreation)
                .Select(o => new OrganisationResponseDto
                {
                    OrgId = o.OrgId,
                    OrgLegalName = o.OrgLegalName,
                    CreatedOn = o.DateOfCreation,
                    PrimaryContactName = o.PrimaryContactName,
                    PrimaryContactEmail = o.PrimaryContactEmail
                })
                .ToPagedResultAsync(
                    queryParams?.PageNumber ?? 1,
                    queryParams?.PageSize ?? 20
                );
        }

        public async Task<OrganisationResponseDto?> GetOrganisationByIdAsync(int orgId)
        {
            var org = await _orgRepository.GetByIdAsync(orgId);
            if (org == null) return null;

            return new OrganisationResponseDto
            {
                OrgId = org.OrgId,
                OrgLegalName = org.OrgLegalName,
                CreatedOn = org.DateOfCreation,
                PrimaryContactName = org.PrimaryContactName,
                PrimaryContactEmail = org.PrimaryContactEmail
            };
        }

        public async Task<OrganisationResponseDto> AddOrganisationAsync(OrganisationDto organisationDto)
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

            return new OrganisationResponseDto
            {
                OrgId = organisation.OrgId,
                OrgLegalName = organisation.OrgLegalName,
                CreatedOn = organisation.DateOfCreation,
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
                BrandName = orgDto.BrandName,
                CountryOfCorp = orgDto.CountryOfCorp,
                DateOfCreation = orgDto.DateOfCreation,
                EntityType = orgDto.EntityType,
                IsActive = orgDto.IsActive,
                PrimaryContactName = orgDto.PrimaryContactName,
                PrimaryContactPhone = orgDto.PrimaryContactPhone,
                PrimaryOperatingCountries = orgDto.PrimaryOperatingCountries,
                RegistrationNumber = orgDto.RegistrationNumber,
                Regulator_LicenseNumber = orgDto.Regulator_LicenseNumber,
                SupportEmail = orgDto.SupportEmail,
                TaxIdentificatioNumber = orgDto.TaxIdentificatioNumber,
                OrgId = id
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
