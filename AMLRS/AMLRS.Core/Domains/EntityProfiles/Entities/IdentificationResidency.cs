using AMLRS.Core.Domains.EntityProfiles.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace AMLRS.Core.Domains.EntityProfiles.Entities
{
    public class IdentificationResidency
    {
        [Key]
        public string EntityId { get; set; }   // PK + FK
        public EntityProfile EntityProfile { get; set; }
        public IdentificationType IdentificationType { get; set; }
        public string? IdentificationNumber { get; set; }
        public string? IDIssuingCountry { get; set; }
        public string? IDIssuingAuthority { get; set; }
        public string? IDIssueDate { get; set; }
        public string? IDExpiryDate { get; set; }
        public string? ProofAddressDocumentType { get; set; }
        public string? ProofAddressIssueDate { get; set; }
        public string? CountryResidence { get; set; }
        public string? ResidencyStatus { get; set; }
        public string? YearsatCurrentAddress { get; set; }
        public string? PreviousAddress { get; set; }
        public string? ScreeningConsent { get; set; }
    }

    
}
