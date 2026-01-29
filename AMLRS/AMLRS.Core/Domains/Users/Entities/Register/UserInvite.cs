using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Core.Domains.Users.Entities.Register
{
    public class UserInvite
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = null!;

        public string InviteToken { get; set; } = null!;

        public DateTime ExpiresAt { get; set; }

        public bool IsUsed { get; set; }

        public DateTime CreatedAt { get; set; }
    }

}
