using AMLRS.Core.Domains.Cases.Entities;
using AMLRS.Core.Domains.SARSTRReports.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.SARSTRReports.Entities
{
    public class STRSARReport
    {
        [Key]
        public string ReportId { get; set; }
        public string CaseId { get; set; }
        public Case Case { get; set; }

        public string DraftNarrative { get; set; }
        public string FinalNarrative { get; set; }

        public bool IsApproved { get; set; }
        public string? ApprovedBy { get; set; }

        public bool SubmittedToRegulator { get; set; }
        public DateTime? SubmissionTimestamp { get; set; }

        public ReportType ReportType { get; set; } // STR / SAR
    }

}
