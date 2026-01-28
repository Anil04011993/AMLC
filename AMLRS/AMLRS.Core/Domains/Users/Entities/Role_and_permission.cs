using AMLRS.Core.Domains.Users.Enums;
using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.Users.Entities
{
    public class Role_and_permission
    {
        [Key]
        public string UserId { get; set; }
        public User User { get; set; }
        public RoleName Role { get; set; } // ENUM
        public AccessLevel AccessLevel { get; set; } // ENUM
        public List<string> Teams { get; set; }
        public List<string> WorkQueueAccess { get; set; }
    }
}
