using AMLRS.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMLRS.Api.Controllers
{
    //[ApiController]
    //[Route("api/admin/invite")]
    public class AdminInviteController : ControllerBase
    {
        private readonly IUserInviteService _service;

        public AdminInviteController(IUserInviteService service)
        {
            _service = service;
        }

        //[HttpPost()]
        public async Task<IActionResult> Invite([FromBody] string email)
        {
            await _service.InviteUserAsync(email);
            return Ok();
        }
    }

}
