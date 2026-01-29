using AMLRS.Core.Domains.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Core.Abstraction.Reposotory
{
    public interface IUserRepository
    {
        Task<User?> LoginAsync(string Email, string Password);
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }

}
