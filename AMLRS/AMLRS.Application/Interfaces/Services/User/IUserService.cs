using AMLRS.Application.DTOs;
using AMLRS.Core.Domains.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<LoggedInUserDto?> LoginAsync(UserLoginRequestDto login);
        Task<bool> VerifyOtpAndLoginAsync(string email, string otp);
    }
}
