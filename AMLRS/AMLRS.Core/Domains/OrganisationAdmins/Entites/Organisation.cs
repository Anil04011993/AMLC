using AMLRS.Core.Domains.Users.Entities;
using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.OrganisationAdmins.Entites
{
    public class Organisation
    {
        [Key]
        public int OrgId { get; set; }
        public string OrgLegalName { get; set; }
        public string BrandName { get; set; }
        public string RegistrationNumber { get; set; }
        public string TaxIdentificatioNumber { get; set; }
        public string EntityType { get; set; }
        public string Regulator_LicenseNumber { get; set; }
        public string CountryOfCorp { get; set; }
        public string PrimaryOperatingCountries { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string PrimaryContactName { get; set; }
        public string PrimaryContactEmail { get; set; }
        public string PrimaryContactPhone { get; set; }
        public string? SupportEmail { get; set; }

        public bool IsActive { get; set; }

    }
}
