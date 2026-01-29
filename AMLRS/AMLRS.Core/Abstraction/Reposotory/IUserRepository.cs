using AMLRS.Core.Domains.Users.Entities;

namespace AMLRS.Core.Abstraction.Reposotory
{
    public interface IUserRepository
    {
        Task<User?> LoginAsync(string Email, string Password);
        //Task<IEnumerable<RoleResponseDto>> GetRolesAsync();
        //Task<UserResponseDto?> GetUserRoleAsync(string username);
        //Task<PermissionResponseDto?> GetPermissionByIdAsync(int permissionId);
    }
}
