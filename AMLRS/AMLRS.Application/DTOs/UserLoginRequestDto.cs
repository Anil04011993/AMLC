using System.ComponentModel.DataAnnotations;

namespace AMLRS.Application.DTOs
{
    public class UserLoginRequestDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [MaxLength(25, ErrorMessage = "Email must be 25 characters or fewer.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
