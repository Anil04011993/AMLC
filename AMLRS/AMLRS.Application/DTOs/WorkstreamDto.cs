using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.DTOs
{
    public class WorkstreamDto
    {
        public string Type { get; set; }      // "KYC Checks"
        public string? CaseId { get; set; }   // nullable
        public string Status { get; set; }    // "In Progress"
    }
}
