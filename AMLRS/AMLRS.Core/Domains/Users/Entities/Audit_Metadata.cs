using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.Users.Entities
{
    public class Audit_Metadata
    {
        [Key]
        public string UserId { get; set; }
        public User User { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedInSystem { get; set; }
        public DateTime? LastRoleChangeAt { get; set; }
        public string AccessContextHistory { get; set; }
        public DateTime? DeactivatedAt { get; set; }
        public string DeactivatedBy { get; set; }
    }
}
