using AMLRS.Core.Domains.Users.Entities.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Core.Abstraction.Reposotory.User
{
    public interface IUserInviteRepository
    {
        Task<UserInvite?> GetByTokenAsync(string token);
        Task AddAsync(UserInvite invite);
        Task MarkUsedAsync(UserInvite invite);
        Task<UserInvite?> GetByEmailAsync(string email);
    }

}
