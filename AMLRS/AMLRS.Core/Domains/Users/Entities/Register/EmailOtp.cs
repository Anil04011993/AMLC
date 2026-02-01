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

        [Required]
        public string Email { get; set; } = null!;

        public string OtpHash { get; set; } = null!;

        public DateTime ExpiresAt { get; set; }

        public bool IsUsed { get; set; }

        public DateTime CreatedAt { get; set; }
    }

}
