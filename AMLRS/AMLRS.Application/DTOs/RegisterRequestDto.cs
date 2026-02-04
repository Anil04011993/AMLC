using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Application.DTOs
{
    public class RegisterRequestDto
    {
        /// <summary>
        /// The user's invitation or registration token.
        /// </summary>
        [Required(ErrorMessage = "Token is required")]
        [MinLength(10, ErrorMessage = "Invalid token")] // adjust length if needed
        public string Token { get; init; } = string.Empty;
    }

}
