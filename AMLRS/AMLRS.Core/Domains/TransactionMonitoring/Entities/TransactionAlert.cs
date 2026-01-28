using AMLRS.Core.Domains.TransactionMonitoring.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.TransactionMonitoring.Entities
{
    public class TransactionAlert
    {
        [Key]
        public string AlertId { get; set; }   // PK

        public string TransactionId { get; set; }
        public Transaction Transaction { get; set; }

        public string GeneratedBy { get; set; }
        public string Description { get; set; }

        public AlertType AlertType { get; set; }
        public AlertSeverity SeverityLevel { get; set; }

        public bool IsResolved { get; set; }
        public DateTime GeneratedAt { get; set; }

        // 1–1 Navigation
        public TransactionAnalysis Analysis { get; set; }
    }


}
