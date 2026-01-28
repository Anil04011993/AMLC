using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.EntityProfiles.Entities
{
    public class ExpandedRiskProfiling
    {
        [Key]
        public string EntityId { get; set; }   // PK + FK
        public EntityProfile EntityProfile { get; set; }
        public int? Geographic_risk_score { get; set; }
        public int? Overall_external_risk_score { get; set; }
        public string? Risk_profile_last_trigger { get; set; }
    }
}
