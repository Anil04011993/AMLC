using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.DTOs
{
    public class SignupRequestDto
    {
        public UsertblDto User { get; set; } = default!;
        public string Token { get; set; } = string.Empty;
    }
}
