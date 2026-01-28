using AMLRS.Core.Domains.Documents.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.Documents.Entities
{
    public class DocumentValidationResult
    {
        [Key]
        public string ResultId { get; set; }
        public string DocumentId { get; set; }
        public Document Document { get; set; }

        public bool IsLivenessDetected { get; set; }
        public bool IsDeepfakeDetected { get; set; }

        public decimal ConfidenceScore { get; set; }
        public ValidationResultStatus ValidationResult { get; set; }

        public DateTime ValidatedAt { get; set; }
        public string Notes { get; set; }
        public DocumentStatus Status { get; set; }
        // Uploaded, InReview, Approved, Rejected, Expired
    }

}
