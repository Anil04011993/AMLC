using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace AMLRS.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ISignupService _service;

        public AuthController(ISignupService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto req)
        {
            await _service.RegisterAsync(req.Token, req.Email, req.Password);
            return Ok("OTP sent");
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp(VerifyOtpRequestDto req)
        {
            await _service.VerifyOtpAsync(req.Email, req.Otp);
            return Ok("Signup completed");
        }
    }

}
