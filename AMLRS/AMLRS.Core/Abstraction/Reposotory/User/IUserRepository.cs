using AMLRS.Core.Domains.OrganisationAdmins.Entites;
using AMLRS.Core.Domains.Users.Entities;
using AMLRS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Core.Abstraction.Reposotory.User
{
    public interface IUserRepository : IRepository<Usertbl, int>
    {
        Task<Usertbl?> LoginAsync(string Email, string Password);
        Task<Usertbl?> GetByEmailAsync(string email);
        IQueryable<UserWithOrgName> GetUsersWithOrgNameQueryable();
    }
}
