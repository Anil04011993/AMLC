using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.Users.Entities
{
    public class Operational_Behavior_Signals
    {
        [Key]
        public string UserId { get; set; }
        public User User { get; set; }
        public string LastPasswordLoginLocation { get; set; }
        public string LastPasswordLoginDevice { get; set; }
        public bool HighRiskUserFlag { get; set; }
        public decimal? RiskScore { get; set; }

    }
}
