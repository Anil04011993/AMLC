using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.DTOs
{
    public class VerifyTokenDTO
    {
        /// <summary>
        /// The user's Token.
        /// </summary>
        public required string Token { get; init; }
    }
}
