using AMLRS.Core.Domains.EntityProfiles.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.EntityProfiles.Entities
{
    public class EnhancedBeneficialOwnershipMetadata
    {
        [Key]
        public string EntityId { get; set; }   // PK + FK
        public EntityProfile EntityProfile { get; set; }
        public EnhancedBeneficialOwnershipComplexity? BeneficialOwnershipComplexity { get; set; }
    }
}
