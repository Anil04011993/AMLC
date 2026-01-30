using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.Users.Entities
{
    public class Decommission_Lifecycle
    {
        [Key]
        public string UserId { get; set; }
        public Usertbl User { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string LinkedEntityId { get; set; }
    }
}
