using AMLRS.Core.Domains.Cases.Entities;
using AMLRS.Core.Domains.KYCScreening.Enums;

namespace AMLRS.Core.Domains.KYCScreening.Entities
{
    public class KycScreeningRun
    {
        public string KycScreeningRunId { get; set; }

        public string CaseId { get; set; }
        public Case Case { get; set; }

        public DateTime ScreenedAt { get; set; }

        public int TotalHits { get; set; }
        public int PendingHits { get; set; }

        public string InitiatedByUserId { get; set; }
        public string InitiatedBy { get; set; }

        public ScreeningStatus Status { get; set; } // Completed / InProgress

        // Navigation
        public ICollection<KycHit> Hits { get; set; }
    }

}
