using AMLRS.Core.Domains.Audit.Entities;
using AMLRS.Core.Domains.Cases.Entities;
using AMLRS.Core.Domains.ClientOutreachs.Entities;
using AMLRS.Core.Domains.Documents.Entities;
using AMLRS.Core.Domains.EntityProfiles.Entities;
using AMLRS.Core.Domains.KYCScreening.Entities;
using AMLRS.Core.Domains.OrganisationAdmins.Entites;
using AMLRS.Core.Domains.OrganisationAdmins.Entities;
using AMLRS.Core.Domains.SARSTRReports.Entities;
using AMLRS.Core.Domains.TransactionMonitoring.Entities;
using AMLRS.Core.Domains.Users.Entities;
using AMLRS.Core.Domains.Users.Entities.Register;
using AMLRS.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace AMLRS.Infrastructure.Data
{
    public class AmlDbContext(DbContextOptions<AmlDbContext> options) : DbContext(options)
    {
        public DbSet<Case> Cases { get; set; }
        public DbSet<EntityProfile> EntityProfiles { get; set; }

        //Invite
        public DbSet<Usertbl> Users => Set<Usertbl>();
        public DbSet<UserInvite> UserInvites => Set<UserInvite>();
        public DbSet<EmailOtp> EmailOtps => Set<EmailOtp>();

        // SECURITY & ACCESS CONTROL
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoleAssignment> UserRoleAssignments { get; set; }

        // CASE WORKSTREAM DATA
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionAlert> TransactionAlerts { get; set; }
        public DbSet<TransactionAnalysis> TransactionAnalyses { get; set; }

        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentValidationResult> DocumentValidationResults { get; set; }

        public DbSet<ClientOutreach> ClientOutreaches { get; set; }
        public DbSet<ClientOutreachResponse> ClientOutreachResponses { get; set; }

        public DbSet<STRSARReport> STRSARReports { get; set; }

        // WORKFLOW & GOVERNANCE

        public DbSet<CaseStatusHistory> CaseStatusHistories { get; set; }
        public DbSet<CaseSlaTracker> CaseSlaTrackers { get; set; }

        // COMPLIANCE & AUDIT
        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

        public DbSet<KycScreeningRun> KycScreeningRuns { get; set; }
        public DbSet<KycHit> KycHits { get; set; }
        public DbSet<KycHitReview> KycHitReviews { get; set; }

        // ENTITY PROFILE – IDENTITY & KYC

        public DbSet<IndividualIdentity> IndividualIdentities { get; set; }
        public DbSet<CompanyIndentity> CompanyIndentities { get; set; }

        public DbSet<ResidentialAddress> ResidentialAddresses { get; set; }
        public DbSet<MailingAddress> MailingAddresses { get; set; }

        public DbSet<IdentificationResidency> IdentificationResidencies { get; set; }
        public DbSet<EmploymentFinancialProfile> EmploymentFinancialProfiles { get; set; }

        public DbSet<AccountPurposeExpectedActivity> AccountPurposeExpectedActivities { get; set; }
        public DbSet<PEPDeclaration> PEPDeclarations { get; set; }
        public DbSet<TaxSelfCertification> TaxSelfCertifications { get; set; }

        public DbSet<BeneficialOwnership> BeneficialOwnerships { get; set; }
        public DbSet<ConsentAndAttestations> ConsentAndAttestations { get; set; }

        public DbSet<MetadataAudit> MetadataAudits { get; set; }
        public DbSet<VersioningLifecycle> VersioningLifecycles { get; set; }

        public DbSet<ScreeningWatchlists> ScreeningWatchlists { get; set; }
        public DbSet<ContinuousMonitoringRiskRefresh> ContinuousMonitoringRiskRefreshes { get; set; }

        public DbSet<ExpandedRiskProfiling> ExpandedRiskProfilings { get; set; }
        public DbSet<ExtendedIdentityVerification> ExtendedIdentityVerifications { get; set; }

        public DbSet<EnhancedBeneficialOwnershipMetadata> EnhancedBeneficialOwnershipMetadatas { get; set; }
        public DbSet<OrgAdmin> Admins { get; set; }
        public DbSet<Organisation> Organisations { get; set; }


        //public DbSet<Auth_and_Security> Auth_and_Securities { get; set; }
        //public DbSet<Role_and_permission> Role_and_permissions { get; set; }
        //public DbSet<Notification_and_preferences> Notification_and_preferences { get; set; }
        //public DbSet<Compliance_Training> Compliance_Trainings { get; set; }
        //public DbSet<Audit_Metadata> Audit_Metadata { get; set; }
        //public DbSet<Optional_UX_Enhancements> Optional_UX_Enhancements { get; set; }
        //public DbSet<Access_Control> Access_Control_ABAC { get; set; }
        //public DbSet<Governance_Compliance_Metadata> Governance_Compliance_Metadata { get; set; }
        //public DbSet<Operational_Behavior_Signals> Operational_Behavior_Signals { get; set; }
        //public DbSet<Integration_External_Identity> Integration_External_Identities { get; set; }
        //public DbSet<Notifications_Alerts> Notifications_Alerts { get; set; }
        //public DbSet<Localization_UX> Localization_UX { get; set; }
        //public DbSet<Decommission_Lifecycle> Decommission_Lifecycles { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CaseConfig());
            builder.ApplyConfiguration(new WorkstreamConfig());
            builder.ApplyConfiguration(new EntityProfileConfig());
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new RoleConfig());
            builder.Entity<AuditLog>().ToTable("AuditLogs");

            //builder.ApplyConfiguration(new CaseslaTrackerConfig());
        }
    }
    
}
