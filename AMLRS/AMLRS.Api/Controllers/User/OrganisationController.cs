using AMLRS.Application.Common;
using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services.User;
using AMLRS.Core.Domains.OrganisationAdmins.Entites;
using Microsoft.AspNetCore.Mvc;

namespace AMLRS.Api.Controllers.User
{
    [ApiController]
    [Route("api")]
    public class OrganisationController : ControllerBase
    {
        private readonly IOrganisationService _orgServices;

        public OrganisationController(IOrganisationService adminServices)
        {
            _orgServices = adminServices;
        }

       
        [HttpGet(ApiRoutes.GetAllOrg)]
        public async Task<IActionResult> GetAllOrganisations()
        {
            var organisations = await _orgServices.GetAllOrganisationsAsync();

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
            var organisation = await _orgServices.GetOrganisationByIdAsync(id);
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

            var createdOrganisation = await _orgServices.AddOrganisationAsync(organisationDto);
            return CreatedAtAction(nameof(GetOrganisationById), new { id = createdOrganisation.OrgId }, createdOrganisation);
        }

        [HttpPut]
        [Route(ApiRoutes.Update_organisation)]
        public async Task<ActionResult> UpdateOrganisation(int id, [FromBody] OrganisationDto orgDto)
        {
            if (orgDto == null || id != orgDto.OrgId)
                return BadRequest();
            var org = await _orgServices.UpdateOrgAsync(id, orgDto);

            return Ok(new ApiResponse<object>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Admin updated",
                Data = org
            });
        }

        [HttpDelete]
        [Route(ApiRoutes.Delete_admin)]
        public async Task<ActionResult> DeleteAdmin(int id)
        {
            var deleted = await _orgServices.DeleteOrgAsync(id);

            if (!deleted)
                return NotFound();

            return Ok(new ApiResponse<object>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Admin updated",
                Data = deleted
            });
        }
    }
}
