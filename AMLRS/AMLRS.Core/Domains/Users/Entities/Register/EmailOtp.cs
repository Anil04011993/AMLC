using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Core.Domains.Users.Entities.Register
{
    public class EmailOtp
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public string OtpHash { get; set; } = null!;

        public DateTime ExpiresAt { get; set; }

        public bool IsUsed { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation
        public User User { get; set; } = null!;
    }

}
