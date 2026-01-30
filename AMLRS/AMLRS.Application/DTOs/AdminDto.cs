using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.DTOs
{
    public class AdminDto
    {
        public Guid AdminId { get; set; }
        public Guid OrgId { get; set; } 
        public string Name { get; set; } 
        public string EmailId { get; set; } 
        public string Role { get; set; } 
    }
}
