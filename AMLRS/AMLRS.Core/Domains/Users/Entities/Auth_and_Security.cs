using AMLRS.Core.Domains.Users.Enums;
using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.Users.Entities
{
    public class Auth_and_Security
    {
        [Key]
        public string UserId { get; set; }
        public Usertbl User { get; set; }
        public bool EmailVerified { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime PasswordLastChangedAt { get; set; }
        public bool MfaEnabled { get; set; }
        public MfaMethod MfaMethod { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public int FailedLoginAttempts { get; set; }
        public bool AccountLocked { get; set; }
        public bool PasswordResetRequired { get; set; }
        public DateTime? LastPasswordResetAt { get; set; }
        public DateTime? SessionExpiryAt { get; set; }
        public string SessionId { get; set; }
        public AuthProvider AuthProvider { get; set; }
        public string AuthProviderUserId { get; set; }
        public bool RefreshTokenRevoked { get; set; }
        public List<string> IpWhitelist { get; set; }
        public int? DeviceTrustScore { get; set; }
        public string LockReason { get; set; }

    }
}
