using AMLRS.Core.Domains.Admin.Entites;
using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.Admin.Entities
{
    public class OrgAdmin
    {
        [Key]
        public Guid AdminId { get; set; }
        public Guid OrgId { get; set; }          // FK → Organisations
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Role { get; set; }          // Admin / Editor / Viewer
        // Navigation property
        public Organisation Org { get; set; }
    }
}
