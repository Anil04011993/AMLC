using AMLRS.Application.Common;
using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services.User;
using AMLRS.Application.Services.User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AMLRS.Api.Controllers.User
{
    [ApiController]
    [Route("api")]
    public class AdminInviteController : ControllerBase
    {
        private readonly IUserInviteService _service;
        private readonly IOrganisationService _adminServices;

        public AdminInviteController(IUserInviteService service, IOrganisationService adminServices)
        {
            _service = service;
            _adminServices = adminServices;
        }

        [HttpPost(ApiRoutes.Invite)]
        public async Task<IActionResult> Invite([FromBody] UsertblDto adminDto)
        {
            try
            {               
                await _service.InviteUserAsync(adminDto);
            }
            catch (Exception) { throw; }           

            return Ok(new ApiResponse<object>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "User Invited",
                Data = true
            });
        }
    }

}
