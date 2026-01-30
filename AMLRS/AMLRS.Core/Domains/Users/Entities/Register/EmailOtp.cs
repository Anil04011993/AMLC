using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.Users.Entities.Register
{
    public class EmailOtp
    {
        [Key]
        public int OtpId { get; set; }

        public int UserId { get; set; }

        public string OtpHash { get; set; } = null!;

        public DateTime ExpiresAt { get; set; }

        public bool IsUsed { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation
        public Usertbl User { get; set; } = null!;
    }

}
