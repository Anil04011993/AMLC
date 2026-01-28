using AMLRS.Core.Domains.Cases.Entities;
using AMLRS.Core.Domains.ClientOutreachs.Enums;
using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.ClientOutreachs.Entities
{
    public class ClientOutreach
    {
        [Key]
        public string OutreachId { get; set; }
        public string CaseId { get; set; }
        public Case Case { get; set; }

        public OutreachChannel Channel { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }

        public DateTime SentAt { get; set; }
        public OutreachStatus Status { get; set; }
    }

}
