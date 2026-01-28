using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.Users.Entities
{
    public class Access_Control
    {
        [Key]
        public string UserId { get; set; }
        public User User { get; set; }
        public string UserAttributesMap { get; set; }
        public string AttributeSetVersion { get; set; }
        public string ContextRoles { get; set; }
    }
}
