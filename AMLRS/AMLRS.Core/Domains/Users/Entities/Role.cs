using AMLRS.Core.Domains.Users.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.Users.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        public RoleName RoleName { get; set; }
        public string Description { get; set; }

        public bool IsComposable { get; set; }

        // Navigation
        public ICollection<UserRoleAssignment> UserAssignments { get; set; }
    }

}
