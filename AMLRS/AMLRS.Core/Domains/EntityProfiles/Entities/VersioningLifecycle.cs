using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.EntityProfiles.Entities
{
    public class VersioningLifecycle
    {
        [Key]
        public string EntityId { get; set; }   // PK + FK
        public EntityProfile EntityProfile { get; set; }
        public DateTime? Validity_start_time {  get; set; }
        public DateTime? Validity_end_time {  get; set; }
        public bool? IsEntityDeleted {  get; set; }
        public string? Source_system {  get; set; }
        public string? Source_record_id { get; set; }
    }
}
