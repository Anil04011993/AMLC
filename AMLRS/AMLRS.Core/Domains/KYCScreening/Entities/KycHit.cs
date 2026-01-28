using AMLRS.Core.Domains.KYCScreening.Enums;

namespace AMLRS.Core.Domains.KYCScreening.Entities
{
    public class KycHit
    {
        public string KycHitId { get; set; }

        public string KycScreeningRunId { get; set; }
        public KycScreeningRun ScreeningRun { get; set; }

        public KycHitType HitType { get; set; } // Sanctions, PEP, AdverseMedia

        public string MatchedName { get; set; }
        public string Source { get; set; } // OFAC, UN, DowJones, etc.

        public string MatchDetails { get; set; } // JSON

        public MatchStrength MatchStrength { get; set; } // Weak / Medium / Strong

        public HitStatus Status { get; set; } // Pending / Cleared / Escalated

        public DateTime CreatedAt { get; set; }

        // Navigation
        public ICollection<KycHitReview> Reviews { get; set; }
    }

}
