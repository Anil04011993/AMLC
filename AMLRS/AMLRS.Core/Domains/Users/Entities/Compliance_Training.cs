using AMLRS.Core.Domains.Users.Enums;
using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.Users.Entities
{
    public class Compliance_Training
    {
        [Key]
        public string UserId { get; set; }
        public Usertbl User { get; set; }
        public bool AmlTrainingCompleted { get; set; }
        public DateTime AmlTrainingDate { get; set; }
        public RoleCertification RoleCertification { get; set; }
        public DateTime? LastCertificationDate { get; set; }
        public bool BackgroundCheckPassed { get; set; }
        public bool SanctionsCheckPassed { get; set; }
    }
}
