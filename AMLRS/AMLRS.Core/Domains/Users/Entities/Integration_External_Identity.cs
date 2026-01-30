using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.Users.Entities
{
    public class Integration_External_Identity
    {
        [Key]
        public string UserId { get; set; }
        public Usertbl User { get; set; }
        public string ExternalIdentityProvider { get; set; }
        public List<string> ExternalGroups { get; set; }
        public string FederationId { get; set; }
    }
}
