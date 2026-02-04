using AMLRS.Application.Common;
using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services.User;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AMLRS.Api.Controllers.User
{
    [ApiController]
    [Route("api")]
    public class SignUpController : ControllerBase
    {
        private readonly ISignupService _service;

        public SignUpController(ISignupService service)
        {
            _service = service;
        }

        [EnableCors("FrontendOnly")]
        [HttpPost(ApiRoutes.VerifyToken)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ValidateToken([FromBody] RegisterRequestDto req)
        {
            var result = await _service.ValidateTokenAsync(req.Token);

            if (!result.IsValid)
            {
                return BadRequest(new ApiResponse<object>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = result.Message,
                });
            }

            return Ok(new ApiResponse<object>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = result.Message, // "Valid link"

                Data = result.CreatedUserOnToken
            });
        }

        [EnableCors("FrontendOnly")]
        [HttpPost(ApiRoutes.SignUp)]
        public async Task<IActionResult> Register(RegisterRequestDto req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<object>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .First().ErrorMessage
                });
            }

            await _service.RegisterAsync(req.Token);
            
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
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<object>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .First().ErrorMessage
                });
            }

            var result = await _service.VerifyOtpAndCreateUserAsync(req.Email, req.Otp);
            if (!result)
                throw new UnauthorizedAccessException("Invalid or expired OTP");
            return Ok(new ApiResponse<object>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Otp verified successfully",
                Data = result
            });
        }

        [HttpPost(ApiRoutes.SetPassword)]
        public async Task<IActionResult> SetPassword(SetPwdDto req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<object>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .First().ErrorMessage
                });
            }

            var result = await _service.SetPasswod(req.Token, req.Password);

            if (!result)
                throw new UnauthorizedAccessException("Cannot set password");
            return Ok(new ApiResponse<object>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "User signup successfully",
                Data = result
            });
        }
    }

}
