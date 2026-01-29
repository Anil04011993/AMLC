using AMLRS.Application.DTOs;
using AMLRS.Core.Domains.Users.Entities;

namespace AMLRS.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<User?> LoginAsync(UserLoginRequestDto login);
       
    }
}
