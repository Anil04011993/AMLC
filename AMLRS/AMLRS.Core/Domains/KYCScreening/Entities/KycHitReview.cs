using AMLRS.Core.Domains.KYCScreening.Enums;
using AMLRS.Core.Domains.Users.Enums;

namespace AMLRS.Core.Domains.KYCScreening.Entities
{
    public class KycHitReview
    {
        public string KycHitReviewId { get; set; }

        public string KycHitId { get; set; }
        public KycHit KycHit { get; set; }

        //public string ReviewedByUserId { get; set; } = string.Empty;
        public string ReviewedBy { get; set; }

        public RoleName ReviewRole { get; set; } // Maker / Checker

        public ReviewDecision Decision { get; set; } // Clear / Escalate / Reject

        public string Comments { get; set; }

        public DateTime ReviewedAt { get; set; }
    }

}
