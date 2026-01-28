using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.EntityProfiles.Entities
{
    public class ContinuousMonitoringRiskRefresh
    {
        [Key]
        public string EntityId { get; set; }   // PK + FK
        public EntityProfile EntityProfile { get; set; }
        public DateTime? Last_risk_refresh_at { get; set; }
        public DateTime? Last_screening_date { get; set; }
    }
}
