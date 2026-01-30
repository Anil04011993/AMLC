using System.ComponentModel.DataAnnotations;

namespace AMLRS.Core.Domains.Users.Entities
{
    public class Access_Control
    {
        [Key]
        public string UserId { get; set; }
        public Usertbl User { get; set; }
        public string UserAttributesMap { get; set; }
        public string AttributeSetVersion { get; set; }
        public string ContextRoles { get; set; }
    }
}
