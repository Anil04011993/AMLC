using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.TransactionMonitoring.Entities
{
    public class TransactionAnalysis
    {
        [Key]
        public string AnalysisId { get; set; }   // PK

        // Explicit FK → TransactionAlert
        //public string AlertId { get; set; }
        //public TransactionAlert Alert { get; set; }

        public string MakerUserId { get; set; }
        public string Narrative { get; set; }

        public string EvidenceMetadata { get; set; } // JSON
        public bool IsApproved { get; set; }

        public string? ReviewedBy { get; set; }
        public string ReviewNotes { get; set; }

        public decimal RiskScore { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ReviewedAt { get; set; }
    }


}
