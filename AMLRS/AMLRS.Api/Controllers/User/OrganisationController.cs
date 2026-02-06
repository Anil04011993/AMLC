using AMLRS.Application.Common;
using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services.User;
using AMLRS.Core.Domains.OrganisationAdmins.Entites;
using AMLRS.Core.QueryModels;
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
        public async Task<IActionResult> GetAllOrganisations([FromQuery] OrgQueryParams queryParam)
        {
            var organisations = await _orgServices.GetAllOrganisationsAsync(queryParam);

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
                return NotFound(new ApiResponse<object>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Organisation not found",
                    Data = organisation
                });

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
            return Ok(new ApiResponse<object>
            {
                StatusCode = StatusCodes.Status201Created,
                Message = "Organisation created successfully",
                Data = createdOrganisation
            });
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
                Message = "Organisation details updated",
                Data = org
            });
        }

        [HttpDelete]
        [Route(ApiRoutes.Delete_organisation)]
        public async Task<ActionResult> DeleteOrganisation(int id)
        {
            var deleted = await _orgServices.DeleteOrgAsync(id);

            if (!deleted)
                return NotFound(new ApiResponse<object>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Organisation not found",
                    Data = deleted
                });

            return Ok(new ApiResponse<object>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Organisation Deleted",
                Data = deleted
            });
        }
    }
}
