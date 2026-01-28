using AMLRS.Core.Domains.EntityProfiles.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.EntityProfiles.Entities
{
    public class MailingAddress
    {
        [Key]
        public string EntityId { get; set; }   // PK + FK
        public EntityProfile EntityProfile { get; set; }
        public string? PhoneNumber { get; set; }
        public string? SecondaryPhone { get; set; }
        public string? EmailAddress { get; set; }
        public string? SecondaryEmail { get; set; }
        public ContactPreference? ContactPreference { get; set; }

    }
}
