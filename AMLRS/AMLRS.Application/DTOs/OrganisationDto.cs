using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.DTOs
{
    public class OrganisationDto { 
        public Guid OrgId { get; set; } 
        public string OrgLegalName { get; set; } 
        public DateTime DateOfCreation { get; set; } 
        public string PrimaryContactName { get; set; } 
        public string PrimaryContactEmail { get; set; } 
    }
}
