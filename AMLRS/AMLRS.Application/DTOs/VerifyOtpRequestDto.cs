using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.DTOs
{
    public class VerifyOtpRequestDto
    {        
        public string Email { get; set; }
        public string Otp { get; set; }
        public string Password { get; set; }
    }
}
