using AMLRS.Core.Domains.EntityProfiles.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.EntityProfiles.Entities
{
    public class ResidentialAddress
    {
        [Key]
        public string EntityId { get; set; }   // PK + FK
        public EntityProfile EntityProfile { get; set; }
        public AddressType? AddressType { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

    }
}
