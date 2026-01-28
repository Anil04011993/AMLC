using AMLRS.Core.Domains.Cases.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.TransactionMonitoring.Entities
{
    public class Transaction
    {
        [Key]
        public string TransactionId { get; set; }
        public string CaseId { get; set; }
        public Case Case { get; set; }

        public string EntityId { get; set; }

        public string Currency { get; set; }
        public decimal Amount { get; set; }

        public string SourceAccount { get; set; }
        public string DestinationAccount { get; set; }
        public string DestinationCountry { get; set; }

        public DateTime TransactionTimestamp { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<TransactionAlert> Alerts { get; set; }
    }

}
