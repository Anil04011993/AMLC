using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.DTOs
{
    public class SignupRequestDto
    {
        public UserDto User { get; set; } = default!;
        public string Token { get; set; } = string.Empty;
    }

    public class UserDto
    {
        public string Id { get; set; } = string.Empty;   // "123"
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // system_admin
    }

}
