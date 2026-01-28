using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text;

namespace AMLRS.Core.Domains.EntityProfiles.Entities
{
    public class TaxSelfCertification
    {
        [Key]
        public string EntityId { get; set; }   // PK + FK
        public EntityProfile EntityProfile { get; set; }
        public bool Customerconfirmsprovidedtaxinformationisaccurate { get; set; }
        public string? TaxIdentificationNumber { get; set; }
        public string? TINCountryofIssue { get; set; }
        public string? ReasonforNoTIN { get; set; }
        public bool Customerdeclarestheyareactingontheirownbehalf { get; set; }
        public bool Customerdeclaresaccountisnotforathirdpartybeneficiary { get; set; }
        public DateTime? SignatureOrAttestationDate { get; set; }
        public string? AttestationMethod { get; set; }
    }
}
