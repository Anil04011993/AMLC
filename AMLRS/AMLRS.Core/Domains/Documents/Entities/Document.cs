using AMLRS.Core.Domains.Cases.Entities;
using AMLRS.Core.Domains.Documents.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace AMLRS.Core.Domains.Documents.Entities
{
    public class Document
    {
        [Key]
        public string DocumentId { get; set; }

        public string CaseId { get; set; }
        public Case Case { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string ContentType { get; set; }
        public long FileSize { get; set; }
        public string FileHash { get; set; }

        public DocumentType DocumentType { get; set; }
        public DocumentStatus Status { get; set; }

        public int Version { get; set; }
        public bool IsLatest { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public string UploadedBy { get; set; }
        public DateTime UploadedAt { get; set; }

        public string? ReviewedBy { get; set; }
        public DateTime? ReviewedAt { get; set; }

        public string? ValidationRemarks { get; set; }
        public DocumentValidationResult ValidationResult { get; set; }

        public bool IsDeleted { get; set; }
    }


}
