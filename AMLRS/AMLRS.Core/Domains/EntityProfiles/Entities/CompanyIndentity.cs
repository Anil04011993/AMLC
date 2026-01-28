using AMLRS.Core.Domains.EntityProfiles.Enums;
using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.EntityProfiles.Entities
{
    public class CompanyIndentity
    {
        [Key]
        public required string EntityId { get; set; }   // PK + FK
        public required BusinessType BusinessType { get; set; }
        public required string Industry { get; set; }
        public DateTime? IncorporationDate { get; set; }
        public string? OperatingCountries { get; set; }
        public EntityProfile EntityProfile { get; set; }
    }
}
