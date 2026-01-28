using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.DTOs
{
    public class CaseOverviewResponseDto
    {
        public string CaseId { get; set; }
        public string EntityId { get; set; }
        public string EntityName { get; set; }
        public string EntityType { get; set; }

        public string CaseOwner { get; set; }
        public string RiskRating { get; set; }

        public DateTime CreatedDate { get; set; }
        public string LastUpdated { get; set; }

        // Identity
        //public IndividualProfileDto IndividualProfile { get; set; }

        // Compliance
        //public ComplianceStatusDto Compliance { get; set; }

        // SLA
        //public SlaStatusDto Sla { get; set; }

        // Workstreams
        public List<CaseWorkstreamDto> Workstreams { get; set; }
    }

}
