using System.ComponentModel.DataAnnotations;

namespace AMLRS.Application.DTOs
{
    public class VerifyOtpRequestDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "OTP must be exactly 6 digits")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "OTP must contain only numbers")]
        public string Otp { get; set; } = string.Empty;
    }

}
