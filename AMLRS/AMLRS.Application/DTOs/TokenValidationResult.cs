using AMLRS.Core.Domains.Users.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.DTOs
{
    public sealed class TokenValidationResult
    {
        public bool IsValid { get; init; }
        public string Message { get; init; } = string.Empty;
        
        public CreatedUserOnToken CreatedUserOnToken { get; init; }
    }

    public class CreatedUserOnToken
    {
        public string Email { get; init; } = string.Empty;
        public string UserName { get; init; } = string.Empty;
        public string OrgName { get; init; } = string.Empty;
        public RoleName Role { get; init; }
    }
}
