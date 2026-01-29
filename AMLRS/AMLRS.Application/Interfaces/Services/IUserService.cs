using AMLRS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserResponseDto?> LoginAsync(UserLoginRequestDto login);
       

    }
}
