using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.Admin.Entites
{
    public class Organisation
    {
        [Key]
        public Guid OrgId { get; set; }
        public string OrgLegalName { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string PrimaryContactName { get; set; }
        public string PrimaryContactEmail { get; set; }
    }
}
