using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.Users.Entities
{
    public class Governance_Compliance_Metadata
    {
        [Key]
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime? ComplianceRoleExpiry { get; set; }
        public string ComplianceFlags { get; set; }
        public DateTime? LastAccessReviewAt { get; set; }
        public DateTime? AccessReviewDueAt { get; set; }
    }
}
