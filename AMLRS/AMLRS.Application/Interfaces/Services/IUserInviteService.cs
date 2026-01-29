using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.Interfaces.Services
{
    public interface IUserInviteService
    {
        Task InviteUserAsync(string email);
    }

}
