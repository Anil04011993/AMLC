using AMLRS.Core.Domains.Cases.Entities;
using AMLRS.Core.Domains.Cases.Enums;
using AMLRS.Core.Domains.Documents.Enums;
using AMLRS.Core.Domains.EntityProfiles.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMLRS.Infrastructure.Config
{
    public class CaseConfig : IEntityTypeConfiguration<Case>
    {
        public void Configure(EntityTypeBuilder<Case> builder)
        {
            builder.ToTable(nameof(Case));
            builder.HasKey(x => x.CaseId);

            builder.Property(e => e.Status)
                   .HasConversion<string>();
            builder.Property(e => e.ServiceType)
                   .HasConversion<string>();
            builder.Property(e => e.RiskLevel)
                   .HasConversion<string>();
            builder.Property(e => e.Tier)
                  .HasConversion<string>();

            builder.Property(e => e.Stage)
                   .HasConversion<string>();

            //builder.Property(x => x.CaseId).UseIdentityColumn();
            builder.HasData(new List<Case>()
            {
                new Case
                {
                    CaseId = "C-2024-0901",
                    CaseNumber = "C-2024-0901",
                    EntityId = "IND-2024-0001",
                    Tier = Tier.Tier_1,
                    Stage = Stage.Screening,
                    RiskLevel = Core.Domains.TransactionMonitoring.Enums.RiskLevel.Medium,
                    Owner = "UserSarahChen",
                    Status = CaseStatus.InProgress,
                    ServiceType = ServiceType.KYCCase,

                    CreatedAt = new DateTime(2025, 01, 12),
                    DueDate = new DateTime(2025, 01, 17),
                    IsLocked = false,
                    RejectionReason = "NoReason"
                },
                new Case
                {
                    CaseId = "C-2024-0902",
                    CaseNumber = "KYC-2024-0901",
                    EntityId = "IND-2024-0001",
                    Tier = Tier.Tier_2,
                    Stage = Stage.Screening,
                    RiskLevel = Core.Domains.TransactionMonitoring.Enums.RiskLevel.Medium,
                    Owner = "UserMichaelTorres",
                    Status = CaseStatus.InProgress,
                    ServiceType = ServiceType.KYCCase,
                    CreatedAt = new DateTime(2025, 01, 12),
                    DueDate = new DateTime(2025, 01, 17),
                    RejectionReason = "NoReason"
                },
                new Case
                {
                    CaseId = "C-2024-9802",
                    CaseNumber = "KYC-2024-0910",
                    EntityId = "IND-2024-0002",
                    Tier = Tier.Tier_1,
                    Stage = Stage.Screening,
                    RiskLevel = Core.Domains.TransactionMonitoring.Enums.RiskLevel.Medium,
                    Owner = "UserMichaelTorres",
                    Status = CaseStatus.InProgress,
                    ServiceType = ServiceType.KYCCase,
                    CreatedAt = new DateTime(2025, 01, 12),
                    DueDate = new DateTime(2025, 01, 17),
                    RejectionReason = "NoReason"
                },
                new Case
                {
                    CaseId = "C-2024-9811",
                    CaseNumber = "KYC-2024-0912",
                    EntityId = "IND-2024-0003",
                    Tier = Tier.Tier_1,
                    Stage = Stage.Screening,
                    RiskLevel = Core.Domains.TransactionMonitoring.Enums.RiskLevel.Medium,
                    Owner = "UserMichaelTorres",
                    Status = CaseStatus.InProgress,
                    ServiceType = ServiceType.KYCCase,
                    CreatedAt = new DateTime(2025, 01, 12),
                    DueDate = new DateTime(2025, 01, 17),
                    RejectionReason = "NoReason"
                },
                new Case
                {
                    CaseId = "C-2024-9812",
                    CaseNumber = "KYC-2024-0920",
                    EntityId = "IND-2024-0004",
                    Tier = Tier.Tier_1,
                    Stage = Stage.Screening,
                    RiskLevel = Core.Domains.TransactionMonitoring.Enums.RiskLevel.Medium,
                    Owner = "UserMichaelTorres",
                    Status = CaseStatus.Assigned,
                    ServiceType = ServiceType.TransactionMonitoring,
                    CreatedAt = new DateTime(2025, 01, 12),
                    DueDate = new DateTime(2025, 01, 17),
                    RejectionReason = "NoReason"
                }
            });
        }
    }
}
