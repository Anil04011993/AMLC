using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.DTOs
{
    public class UserLoginRequestDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; } // plain password from client
    }
}
