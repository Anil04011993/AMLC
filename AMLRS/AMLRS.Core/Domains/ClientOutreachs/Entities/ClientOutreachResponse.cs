using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.ClientOutreachs.Entities
{
    public class ClientOutreachResponse
    {
        [Key]
        public string ResponseId { get; set; }

        public string OutreachId { get; set; }
        public ClientOutreach Outreach { get; set; }

        public string ResponseMessage { get; set; }
        public DateTime RespondedAt { get; set; }

        public bool IsSatisfactory { get; set; }
    }

}
