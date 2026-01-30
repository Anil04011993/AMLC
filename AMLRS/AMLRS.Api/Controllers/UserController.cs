using AMLRS.Application.Common;
using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AMLRS.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [EnableCors("FrontendOnly")]
        [HttpPost(ApiRoutes.Login)]
        [ProducesResponseType(typeof(LoggedInUserDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto login)
        {
            var result = await _userService.LoginAsync(login);
            if (result == null)
                return Unauthorized(new { Message = "Login failed: Invalid email or password" });

            return Ok(result);
        }
    }
}
