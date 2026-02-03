using AMLRS.Core.Domains.Users.Enums;
using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.Users.Entities
{    
    public class Usertbl
    {
        // Core Identity
        [Key]
        public int UserId { get; set; }
        public int OrgId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? PreferredName { get; set; }
        public required string Email { get; set; }
        public string? Password { get; set; }
        public string? SecondaryEmail { get; set; }
        public string? PhoneNumber { get; set; }
        public string? SecondaryPhone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; }
        public RoleName Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        
        //public Auth_and_Security Auth_and_Security { get; set; }

        //public Role_and_permission Role_and_permission { get; set; }

        //public Notification_and_preferences Notification_and_preferences { get; set; }

        //public Compliance_Training Compliance_Training { get; set; }

        //public Audit_Metadata Audit_Metadata { get; set; }

        //public Optional_UX_Enhancements Optional_UX_Enhancements { get; set; }

        //public Access_Control Access_Control_ABAC { get; set; }

        //public Governance_Compliance_Metadata Governance_Compliance_Metadata { get; set; }

        //public Operational_Behavior_Signals Operational_Behavior_Signals { get; set; }

        //public Integration_External_Identity Integration_External_Identity { get; set; }

        //public Notifications_Alerts Notifications_Alerts { get; set; }

        //public Localization_UX Localization_UX { get; set; }

        //public Decommission_Lifecycle Decommission_Lifecycle { get; set; }
    }
}
