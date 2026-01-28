using AMLRS.Core.Domains.EntityProfiles.Enums;
using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.EntityProfiles.Entities
{
    public class BeneficialOwnership
    {
        [Key]
        public string EntityId { get; set; }   // PK + FK
        public EntityProfile EntityProfile { get; set; }
        public string? OwnerEntityId { get; set; }
        public string? OwnershipPercentage { get; set; }
        public ControlType? ControlType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
