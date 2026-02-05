using AMLRS.Core.Domains.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Infrastructure.Data
{
    public class UserWithOrgName
    {
        public Usertbl User { get; set; }
        public string OrgName { get; set; }
    }

}
