using AMLRS.Application.Common;
using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services.User;
using AMLRS.Application.Services.User;
using AMLRS.Core.QueryModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AMLRS.Api.Controllers.User
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
                throw new UnauthorizedAccessException("Invalid email or password");

            return Ok(new ApiResponse<LoggedInUserDto>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Otp sent",
                Data = result
            });
        }

        //[HttpPost(ApiRoutes.VerifyOtp)]
        //public async Task<IActionResult> VerifyOtp(VerifyOtpRequestDto req)
        //{
        //    var result = await _userService.VerifyOtpAndLoginAsync(req.Email, req.Otp);
        //    if (!result)            
        //        throw new UnauthorizedAccessException("Invalid or expired OTP");

        //    return Ok(new ApiResponse<object>
        //    {
        //        StatusCode = StatusCodes.Status200OK,
        //        Message = "Login successful",
        //        Data = true
        //    });
        //}

        [HttpGet(ApiRoutes.Getalluser)]
        public async Task<IActionResult> GetAllusers([FromQuery] CaseQueryParams queryParam)
        {
            var users = await _userService.GetAllUsersAsync(queryParam);

            if (users == null || users.Users == null || !users.Users.Any())
            {
                return NotFound(new ApiResponse<object>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "No user found",
                    Data = null
                });
            }
            return Ok(new ApiResponse<object>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "All users",
                Data = users
            });
        }

        //Forgot password?

        [HttpPost(ApiRoutes.ForgotPassword)]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto req)
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

            var res = await _userService.ForgotPasswordAsync(req.Email);

            // Do NOT reveal if email exists or not
            return Ok(new ApiResponse<object>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Otp has been sent on email.",
                Data = res
            });
        }

        [HttpPost(ApiRoutes.ResetPassword)]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto req)
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

            var res = await _userService.ResetPasswodAsync(req);

            // Do NOT reveal if email exists or not
            return Ok(new ApiResponse<object>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Otp has been sent on email.",
                Data = res
            });
        }

        [HttpPost(ApiRoutes.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ResetPasswordDto req)
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

            var res = await _userService.ResetPasswodAsync(req);

            // Do NOT reveal if email exists or not
            return Ok(new ApiResponse<object>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Otp has been sent on email.",
                Data = res
            });
        }
    }

}
