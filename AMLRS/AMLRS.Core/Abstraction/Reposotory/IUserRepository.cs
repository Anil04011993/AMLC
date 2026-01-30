using AMLRS.Core.Domains.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Core.Abstraction.Reposotory
{
    public interface IUserRepository
    {
        Task<Usertbl?> LoginAsync(string Email, string Password);
        Task<Usertbl?> GetByEmailAsync(string email);
        Task AddAsync(Usertbl user);
    }

}
