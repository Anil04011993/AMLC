using AMLRS.Core.Domains.Cases.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace AMLRS.Core.Domains.Cases.Entities
{
    public class CaseStatusHistory
    {
        [Key]
        public long HistoryId { get; set; }

        public string CaseId { get; set; }
        public Case Case { get; set; }

        public CaseStatus OldStatus { get; set; }
        public CaseStatus NewStatus { get; set; }

        public string ChangedBy { get; set; }
        public string ChangeReason { get; set; }

        public DateTime ChangedAt { get; set; }
    }

}
