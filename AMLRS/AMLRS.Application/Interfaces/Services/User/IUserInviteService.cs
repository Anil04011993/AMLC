using AMLRS.Application.DTOs;
using AMLRS.Core.Domains.Users.Enums;

namespace AMLRS.Application.Interfaces.Services.User
{
    public interface IUserInviteService
    {
        Task InviteUserAsync(InviteUserRequestDto adminDto);
    }

}
