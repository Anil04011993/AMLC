using AMLRS.Core.Domains.Cases.Enums;
using AMLRS.Core.Domains.Documents.Enums;
using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.Cases.Entities
{
    public class Workstream
    {
        [Key]
        public required string WorkstreamId { get; set; }

        public ServiceType Type { get; set; }
        public CaseStatus Status { get; set; }

        public string? Maker { get; set; }
        public string? Owner { get; set; }

        // Optional FK → Case (if applicable)
        public string? CaseId { get; set; }
        public Case? Case { get; set; }
    }
}
