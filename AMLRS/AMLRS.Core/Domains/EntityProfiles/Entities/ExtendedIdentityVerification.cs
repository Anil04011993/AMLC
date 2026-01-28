using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.EntityProfiles.Entities
{
    public class ExtendedIdentityVerification
    {
        [Key]
        public string EntityId { get; set; }   // PK + FK
        public EntityProfile EntityProfile { get; set; }
        public string? Identity_verification_provider { get; set; }
        public string? Identity_verification_result { get; set; }
        public int? Biometric_match_score { get; set; }
    }                                                       
}
