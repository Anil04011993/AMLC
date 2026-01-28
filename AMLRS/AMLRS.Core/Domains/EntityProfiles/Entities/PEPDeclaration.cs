using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace AMLRS.Core.Domains.EntityProfiles.Entities
{
    public class PEPDeclaration
    {
        [Key]
        public string EntityId { get; set; }   // PK + FK
        public EntityProfile EntityProfile { get; set; }
        public bool IscustomerPoliticallyExposedPerson { get; set; }
        public bool IscustomerfamilymemberorcloseassociateofaPEP { get; set; }
        public string? PEPCategory { get; set; }
        public string? PEPName { get; set; }
        public string? Position_Role { get; set; }
        public string? Country_Jurisdiction { get; set; }
        public string? RelationshiptoCustomer { get; set; }
        public string? DateRoleStarted { get; set; }
        public string? DateRoleEnded { get; set; }
        public string? Notes { get; set; }
    }
}
