using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.DTOs
{
    public class LoggedInUserDto
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PreferredName { get; set; }
        public string? PhoneNumber { get; set; }
    }

}
