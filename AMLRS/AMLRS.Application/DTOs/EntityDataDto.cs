using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.DTOs
{
    public class EntityDataDto
    {
        public string? MasterCaseId { get; set; }
        public string EntityId { get; set; }
        public string? EntityName { get; set; }

        public string? Tier { get; set; }
        public string? Stage { get; set; }
        public string? OverallRisk { get; set; }
        public string? OverallStatus { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }

        public bool IsOverdue { get; set; }
        public string? Owner { get; set; }

        public List<WorkstreamDto> Workstreams { get; set; } = new();
    }

}
