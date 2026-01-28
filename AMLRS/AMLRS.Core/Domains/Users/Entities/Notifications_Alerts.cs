using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.Users.Entities
{
    public class Notifications_Alerts
    {
        [Key]
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime? LastNotificationSentAt { get; set; }
        public bool NotificationOptOut { get; set; }
    }
}
