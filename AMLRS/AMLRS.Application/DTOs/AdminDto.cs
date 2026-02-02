using AMLRS.Core.Domains.Users.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.DTOs
{
    public class AdminDto
    {
        public int AdminId { get; set; }
        public string OrgName { get; set; } 
        public string Name { get; set; } 
        public string EmailId { get; set; } 
        public RoleName Role { get; set; } 
    }
}
