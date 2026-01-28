using AMLRS.Core.Domains.Users.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.Users.Entities
{
    public class Localization_UX
    {
        [Key]
        public string UserId { get; set; }
        public User User { get; set; }
        public string TimeZone { get; set; }
        public UiThemePreference UiThemePreference { get; set; }
    }
}
