using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMLRS.Core.Domains.Admin.Entities;
using AMLRS.Core.Abstraction.Repository;
using AMLRS.Application.Interfaces.Services;
using AMLRS.Application.DTOs;
using AMLRS.Core.Domains.Admin.Entites;

namespace AMLRS.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        // ------------------- Admin -------------------

        public async Task<IEnumerable<AdminDto>> GetAllAdminsAsync()
        {
            var admins = await _adminRepository.GetAllAdminsAsync();
            return admins.Select(a => new AdminDto
            {
                AdminId = a.AdminId,
                OrgId = a.OrgId,
                Name = a.Name,
                EmailId = a.EmailId,
                Role = a.Role
            });
        }

        public async Task<AdminDto?> GetAdminByIdAsync(Guid adminId)
        {
            var admin = await _adminRepository.GetAdminByIdAsync(adminId);
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
                AdminId = Guid.NewGuid(),
                OrgId = adminDto.OrgId,
                Name = adminDto.Name,
                EmailId = adminDto.EmailId,
                Role = adminDto.Role
            };

            var created = await _adminRepository.AddAdminAsync(admin);

            return new AdminDto
            {
                AdminId = created.AdminId,
                OrgId = created.OrgId,
                Name = created.Name,
                EmailId = created.EmailId,
                Role = created.Role
            };
        }

        // ------------------- Organisation -------------------

        public async Task<IEnumerable<OrganisationDto>> GetAllOrganisationsAsync()
        {
            var organisations = await _adminRepository.GetAllOrganisationsAsync();
            return organisations.Select(o => new OrganisationDto
            {
                OrgId = o.OrgId,
                OrgLegalName = o.OrgLegalName,
                DateOfCreation = o.DateOfCreation,
                PrimaryContactName = o.PrimaryContactName,
                PrimaryContactEmail = o.PrimaryContactEmail
            });
        }

        public async Task<OrganisationDto?> GetOrganisationByIdAsync(Guid orgId)
        {
            var org = await _adminRepository.GetOrganisationByIdAsync(orgId);
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
                OrgId = Guid.NewGuid(),
                OrgLegalName = organisationDto.OrgLegalName,
                DateOfCreation = organisationDto.DateOfCreation,
                PrimaryContactName = organisationDto.PrimaryContactName,
                PrimaryContactEmail = organisationDto.PrimaryContactEmail,
                //CreatedAt = DateTime.UtcNow,
                //UpdatedAt = DateTime.UtcNow
            };

            var created = await _adminRepository.AddOrganisationAsync(organisation);

            return new OrganisationDto
            {
                OrgId = created.OrgId,
                OrgLegalName = created.OrgLegalName,
                DateOfCreation = created.DateOfCreation,
                PrimaryContactName = created.PrimaryContactName,
                PrimaryContactEmail = created.PrimaryContactEmail
            };
        }
    }
}
