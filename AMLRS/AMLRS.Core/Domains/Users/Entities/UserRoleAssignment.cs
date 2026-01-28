using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.Users.Entities
{
    public class UserRoleAssignment
    {
        [Key]
        public string UserRoleAssignmentId { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public DateTime AssignedAt { get; set; }
    }

}
