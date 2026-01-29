using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMLRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto login)
        {
            var result = await _userService.LoginAsync(login);
            if (result == null)
                return Unauthorized(new { Message = "Invalid credentials or user not registered" });

            return Ok(result);
        }
    }
}
