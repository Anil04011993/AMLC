using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.Cases.Entities
{
    public class CaseSlaTracker
    {
        [Key]
        public string SlaTrackerId { get; set; }

        public string CaseId { get; set; }
        public Case Case { get; set; }

        public DateTime DueDate { get; set; }
        public bool IsBreached { get; set; }

        public DateTime? BreachedAt { get; set; }
    }

}
