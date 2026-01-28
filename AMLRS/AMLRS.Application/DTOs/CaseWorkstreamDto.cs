using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.DTOs
{
    public class CaseWorkstreamDto
    {
        public string Service { get; set; }       // KYC, TM, Outreach
        public string CaseId { get; set; }
        public string Status { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }

        public string Maker { get; set; }
        public string Owner { get; set; }
    }

}
