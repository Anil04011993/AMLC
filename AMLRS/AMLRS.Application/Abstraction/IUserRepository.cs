using AMLRS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.Abstraction
{
    public interface IUserRepository
    {
        Task<UserResponseDto?> LoginAsync(UserLoginRequestDto login);
        //Task<IEnumerable<RoleResponseDto>> GetRolesAsync();
        //Task<UserResponseDto?> GetUserRoleAsync(string username);
        //Task<PermissionResponseDto?> GetPermissionByIdAsync(int permissionId);
    }
}
