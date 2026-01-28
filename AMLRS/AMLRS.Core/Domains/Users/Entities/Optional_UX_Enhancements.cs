using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.Users.Entities
{
    public class Optional_UX_Enhancements
    {
        [Key]
        public string UserId { get; set; }
        public User User { get; set; }
        public string AvatarUrl { get; set; }
        public string Notes { get; set; }
        public string PreferredDashboard { get; set; }
    }
}
