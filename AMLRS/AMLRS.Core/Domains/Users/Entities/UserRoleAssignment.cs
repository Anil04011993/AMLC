using AMLRS.Core.Domains.Users.Enums;
using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.Users.Entities
{
    public class UserRoleAssignment
    {
        [Key]
        public int UserRoleAssignmentId { get; set; }

        public int UserId { get; set; }
        public Usertbl User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public DateTime AssignedAt { get; set; }
    }

}
