using AMLRS.Core.Domains.Users.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Core.Domains.Users.Entities.Register
{
    public class UserInvite
    {
        public int Id { get; set; }
        public int OrgId { get; set; }
        public string Email { get; set; } = null!;
        public string InviteToken { get; set; } = null!;
        public RoleName Role { get; set; } 
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }
    }
}
