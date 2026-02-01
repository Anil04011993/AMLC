using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.Interfaces.Services.User
{
    public interface IUserInviteService
    {
        Task InviteUserAsync(string email, string role);
    }

}
