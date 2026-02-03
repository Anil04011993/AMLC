using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.DTOs
{
    public sealed class TokenValidationResult
    {
        public bool IsValid { get; init; }
        public string Message { get; init; } = string.Empty;
    }

}
