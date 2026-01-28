using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.EntityProfiles.Entities
{
    public class IndividualIdentity
    {
        [Key]
        public required string EntityId { get; set; }   // PK + FK
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public  required string LastName { get; set; }
        public string? PreferredName { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required string Gender { get; set; }
        public required string Nationality { get; set; }
        public string? SecondaryNationality { get; set; }
        public string? CountryOfBirth { get; set; }
        public string? CityOfBirth { get; set; }
        public string? MaterialStatus { get; set; }
        public string? LanguagePreference { get; set; }
        public EntityProfile EntityProfile { get; set; }
    }
}
