using AMLRS.Core.Domains.EntityProfiles.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.EntityProfiles.Entities
{
    public class ConsentAndAttestations
    {
        [Key]
        public string EntityId { get; set; }   // PK + FK
        public EntityProfile EntityProfile { get; set; }
        public bool? ScreeningConsent { get; set; }
        public DateTime? ConsentDate { get; set; }
        public bool? DataAccuracyAttestation { get; set; }
        public bool? ActingOnOwnBehalf { get; set; }
        public bool? ThirdPartyBeneficiary { get; set; }
        public AttestationMethod? AttestationMethod { get; set; }
        public DateTime? AttestedAt { get; set; }

    }
}
