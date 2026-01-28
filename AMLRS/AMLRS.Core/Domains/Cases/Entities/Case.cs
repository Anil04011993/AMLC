using AMLRS.Core.Domains.Cases.Enums;
using AMLRS.Core.Domains.ClientOutreachs.Entities;
using AMLRS.Core.Domains.Common.Entities;
using AMLRS.Core.Domains.Documents.Entities;
using AMLRS.Core.Domains.Documents.Enums;
using AMLRS.Core.Domains.EntityProfiles.Entities;
using AMLRS.Core.Domains.EntityProfiles.Enums;
using AMLRS.Core.Domains.KYCScreening.Entities;
using AMLRS.Core.Domains.SARSTRReports.Entities;
using AMLRS.Core.Domains.TransactionMonitoring.Entities;
using AMLRS.Core.Domains.TransactionMonitoring.Enums;
using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.Cases.Entities
{
    public class Case// : BaseEntity<string>
    {
        [Key]
        public required string CaseId { get; set; }
        public required string EntityId { get; set; }
        public EntityProfile Entity { get; set; }
        public required Tier? Tier { get; set; }
        public required Stage? Stage { get; set; }
        public required RiskLevel RiskLevel { get; set; }
        public required CaseStatus Status { get; set; }
        public bool IsOverDue { get; set; }
        public ServiceType ServiceType { get; set; }
        public string? Owner { get; set; }
        public string? ReviewerUserId { get; set; }
        public string? TeamLeadUserId { get; set; }
        public string CaseNumber { get; set; } // Unique

        public DateTime DueDate { get; set; }
        public int SlaDays { get; set; }
        public bool IsLocked { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation
        public ICollection<Workstream> Workstreams { get; set; } = new List<Workstream>();
        public string RejectionReason { get; set; }

        // Navigation
        public ICollection<Document> Documents { get; set; }
        public ICollection<KycScreeningRun> KycScreeningRuns { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<ClientOutreach> ClientOutreaches { get; set; }
        public ICollection<STRSARReport> Reports { get; set; }
        public ICollection<CaseStatusHistory> StatusHistory { get; set; }
    }

}
