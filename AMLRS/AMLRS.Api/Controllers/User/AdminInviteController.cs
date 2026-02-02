using AMLRS.Application.Common;
using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace AMLRS.Api.Controllers.User
{
    [ApiController]
    [Route("api")]
    public class AdminInviteController : ControllerBase
    {
        private readonly IUserInviteService _service;

        public AdminInviteController(IUserInviteService service)
        {
            _service = service;
        }

        [HttpPost(ApiRoutes.Invite)]
        public async Task<IActionResult> Invite([FromBody] string email, string role)
        {
            try
            {
                await _service.InviteUserAsync(email, role);
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
