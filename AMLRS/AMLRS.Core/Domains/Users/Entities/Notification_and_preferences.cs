using AMLRS.Core.Domains.Users.Enums;
using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.Users.Entities
{
    public class Notification_and_preferences
    {
        [Key]
        public string UserId { get; set; }
        public Usertbl User { get; set; }
        public NotificationChannels NotificationChannels { get; set; }
        public NotificationFrequency NotificationFrequency { get; set; }
        public LanguagePreference LanguagePreference { get; set; }

    }
}
