using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.EntityProfiles.Entities
{
    public class MetadataAudit
    {
        [Key]
        public string EntityId { get; set; }   // PK + FK
        public EntityProfile EntityProfile { get; set; }
        public string? Created_by {  get; set; }
        public DateTime? Last_reviewed_at {  get; set; }
        public DateTime? Last_refreshed_at {  get; set; }
        public string? Data_source {  get; set; }
        public int? Confidence_score {  get; set; }
        public bool? Is_snapshot_locked {  get; set; }

    }
}
