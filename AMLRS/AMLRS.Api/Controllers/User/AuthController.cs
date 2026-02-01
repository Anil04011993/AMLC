using AMLRS.Application.Common;
using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace AMLRS.Api.Controllers.User
{
    //[ApiController]
    //[Route("api")]
    public class AuthController : ControllerBase
    {
        private readonly ISignupService _service;

        public AuthController(ISignupService service)
        {
            _service = service;
        }

        [HttpPost(ApiRoutes.SignUp)]
        public async Task<IActionResult> Register(RegisterRequestDto req)
        {
            await _service.RegisterAsync(req.Token, req.Email);
            
            return Ok(new ApiResponse<object>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Otp sent",
                Data = true
            });
        }

        [HttpPost(ApiRoutes.VerifyRegOtp)]
        public async Task<IActionResult> VerifyOtp(VerifyOtpRequestDto req)
        {
            var result = await _service.VerifyOtpAndCreateUserAsync(req.Email, req.Otp, req.Password);
            if (!result)
                throw new UnauthorizedAccessException("Invalid or expired OTP");
            return Ok(new ApiResponse<object>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Signup completed",
                Data = true
            });
        }
    }

}
