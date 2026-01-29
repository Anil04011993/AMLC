using AMLRS.Application.DTOs;
using AMLRS.Core.Domains.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<User?> LoginAsync(UserLoginRequestDto login);
       
    }
}
