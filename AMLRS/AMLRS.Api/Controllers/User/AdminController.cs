using AMLRS.Application.Common;
using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services.User;
using AMLRS.Core.Domains.OrganisationAdmins.Entites;
using Microsoft.AspNetCore.Mvc;

namespace AMLRS.Api.Controllers.User
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

        [HttpGet(ApiRoutes.GetAllOrgAdmins)]
        public async Task<IActionResult> GetAllAdmins()
        {
            var admins = await _adminServices.GetAllAdminsAsync();
           
            return Ok(new ApiResponse<object>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "All admins",
                Data = admins
            });
        }

        [HttpGet(ApiRoutes.GetOrgAdminById)]
        public async Task<IActionResult> GetAdminById(int id)
        {
            var admin = await _adminServices.GetAdminByIdAsync(id);
            if (admin == null)
                return NotFound();

            return Ok(new ApiResponse<object>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Get Admin",
                Data = admin
            });
        }

        [HttpPost(ApiRoutes.AddOrgadmin)]
        public async Task<IActionResult> AddAdmin([FromBody] AdminDto adminDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdAdmin = await _adminServices.AddAdminAsync(adminDto);
            return CreatedAtAction(nameof(GetAdminById), new { id = createdAdmin.AdminId }, createdAdmin);
        }

        // ----------------------------- Organisation ---------------------------------

        [HttpGet(ApiRoutes.GetAllOrg)]
        public async Task<IActionResult> GetAllOrganisations()
        {
            var organisations = await _adminServices.GetAllOrganisationsAsync();

            return Ok(new ApiResponse<object>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "All Organisations",
                Data = organisations
            });
        }

        [HttpGet(ApiRoutes.GetOrgById)]
        public async Task<IActionResult> GetOrganisationById(int id)
        {
            var organisation = await _adminServices.GetOrganisationByIdAsync(id);
            if (organisation == null)
                return NotFound();

            return Ok(new ApiResponse<object>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Get Organisation",
                Data = organisation
            });
        }

        [HttpPost(ApiRoutes.AddOrganisation)]
        public async Task<IActionResult> AddOrganisation([FromBody] OrganisationDto organisationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdOrganisation = await _adminServices.AddOrganisationAsync(organisationDto);
            return CreatedAtAction(nameof(GetOrganisationById), new { id = createdOrganisation.OrgId }, createdOrganisation);
        }
    }
}
