using AMLRS.Core.Domains.Admin.Entites;
using AMLRS.Core.Domains.Users.Enums;
using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.Admin.Entities
{
    public class OrgAdmin
    {
        [Key]
        public int AdminId { get; set; }
        public int OrgId { get; set; }          // FK → Organisations
        public string Name { get; set; }
        public string EmailId { get; set; }
        public RoleName Role { get; set; }          // Admin / Editor / Viewer
        // Navigation property
        public Organisation Org { get; set; }
    }
}
