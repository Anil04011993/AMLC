using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.DTOs
{
    public class RegisterRequestDto
    {
        /// <summary>
        /// The user's Token.
        /// </summary>
        public required string Token { get; init; }
        /// <summary>
        /// The user's email address which acts as a user name.
        /// </summary>
        public required string Email { get; init; }

        /// <summary>
        /// The user's password.
        /// </summary>
        public required string Password { get; init; }
    }
}
