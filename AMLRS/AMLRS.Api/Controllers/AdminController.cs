using AMLRS.Application.Common;
using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMLRS.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminServices;

        public AdminController(IAdminService adminServices)
        {
            _adminServices = adminServices;
        }

        // ------------------- Admin -------------------

        // GET: api/admin/admins
        [HttpGet(ApiRoutes.GetAllOrgAdmins)]
        public async Task<IActionResult> GetAllAdmins()
        {
            var admins = await _adminServices.GetAllAdminsAsync();
            return Ok(admins);
        }

        // GET: api/admin/admins/{id}
        [HttpGet(ApiRoutes.GetOrgAdminById)]
        public async Task<IActionResult> GetAdminById(int id)
        {
            var admin = await _adminServices.GetAdminByIdAsync(id);
            if (admin == null)
                return NotFound();

            return Ok(admin);
        }

        // POST: api/admin/admins
        [HttpPost(ApiRoutes.AddOrgadmin)]
        public async Task<IActionResult> AddAdmin([FromBody] AdminDto adminDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdAdmin = await _adminServices.AddAdminAsync(adminDto);
            return CreatedAtAction(nameof(GetAdminById), new { id = createdAdmin.AdminId }, createdAdmin);
        }

        // ------------------- Organisation -------------------

        // GET: api/admin/organisations
        [HttpGet(ApiRoutes.GetAllOrg)]
        public async Task<IActionResult> GetAllOrganisations()
        {
            var organisations = await _adminServices.GetAllOrganisationsAsync();
            return Ok(organisations);
        }

        // GET: api/admin/organisations/{id}
        [HttpGet(ApiRoutes.GetOrgById)]
        public async Task<IActionResult> GetOrganisationById(int id)
        {
            var organisation = await _adminServices.GetOrganisationByIdAsync(id);
            if (organisation == null)
                return NotFound();

            return Ok(organisation);
        }

        // POST: api/admin/organisations
        [HttpPost("organisation")]
        public async Task<IActionResult> AddOrganisation([FromBody] OrganisationDto organisationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdOrganisation = await _adminServices.AddOrganisationAsync(organisationDto);
            return CreatedAtAction(nameof(GetOrganisationById), new { id = createdOrganisation.OrgId }, createdOrganisation);
        }
    }
}
