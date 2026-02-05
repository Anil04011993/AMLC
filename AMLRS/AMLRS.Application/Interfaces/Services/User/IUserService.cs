using AMLRS.Application.DTOs;
using AMLRS.Core.Domains.Users.Entities;
using AMLRS.Core.QueryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<LoggedInUserDto?> LoginAsync(UserLoginRequestDto login);
        Task<bool> VerifyOtpAndLoginAsync(string email, string otp);
        Task<PagedResult<InviteUserRequestDto>> GetAllUsersAsync(CaseQueryParams queryParams);
        Task<bool> ForgotPasswordAsync(string email);
        Task<bool> ResetPasswodAsync(ResetPasswordDto req);
    }
}
