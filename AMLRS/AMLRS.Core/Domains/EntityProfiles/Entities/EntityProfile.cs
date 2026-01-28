using AMLRS.Core.Domains.Cases.Entities;
using AMLRS.Core.Domains.Common.Entities;
using AMLRS.Core.Domains.EntityProfiles.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.EntityProfiles.Entities
{
    public class EntityProfile// : BaseEntity<string>
    {
        [Key]
        [Required]
        public required string EntityId { get; set; }
        public required string EntityName { get; set; }
        public string? LegalName { get; set; } 
        public required EntityType? EntityType { get; set; } // Individual / Company
        public string? PrimaryIdentifier { get; set; }
        public string? CountryOfIncorporation { get; set; }
        public string? LifeCycleStatus { get; set; }
        public string? VerificationStatus { get; set; }
        public int RiskRating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IndividualIdentity IndividualIdentity { get; set; }
        public CompanyIndentity CompanyIndentity { get; set; }
        public ResidentialAddress ResidentialAddress { get; set; }
        public MailingAddress MailingAddress { get; set; }
        public IdentificationResidency IdentificationResidency { get; set; }
        public EmploymentFinancialProfile EmploymentFinancialProfile { get; set; }
        public AccountPurposeExpectedActivity AccountPurposeExpectedActivity { get; set; }
        public PEPDeclaration PEPDeclaration { get; set; }
        public TaxSelfCertification TaxSelfCertification { get; set; }        
        public BeneficialOwnership BeneficialOwnership { get; set; }
        public ConsentAndAttestations ConsentAndAttestations { get; set; }
        public MetadataAudit MetadataAudit { get; set; }
        public VersioningLifecycle VersioningLifecycle { get; set; }
        public ScreeningWatchlists ScreeningWatchlists { get; set; }
        public ContinuousMonitoringRiskRefresh ContinuousMonitoringRiskRefresh { get; set; }
        public ExpandedRiskProfiling ExpandedRiskProfiling { get; set; }
        public ExtendedIdentityVerification ExtendedIdentityVerification { get; set; }
        public EnhancedBeneficialOwnershipMetadata EnhancedBeneficialOwnershipMetadata { get; set; }
        public ICollection<Case> Cases { get; set; } = new List<Case>();
    }

    

}
