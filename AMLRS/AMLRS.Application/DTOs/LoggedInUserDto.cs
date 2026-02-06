using AMLRS.Core.Domains.Users.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.DTOs
{
    public class LoggedInUserDto
    {
        public string Email { get; set; }
        public int OrgID { get; set; }
    }

}
