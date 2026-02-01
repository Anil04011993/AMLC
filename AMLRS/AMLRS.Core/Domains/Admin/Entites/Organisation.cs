using AMLRS.Core.Domains.Admin.Entities;
using AMLRS.Core.Domains.Cases.Entities;
using AMLRS.Core.Domains.Users.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.Admin.Entites
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

        public ICollection<OrgAdmin> OrgAdmins { get; set; } = new List<OrgAdmin>();
        public ICollection<Usertbl> Users { get; set; } = new HashSet<Usertbl>();
    }
}
