using AMLRS.Core.Domains.Users.Enums;
using System.ComponentModel.DataAnnotations;

namespace AMLRS.Application.DTOs
{
    public class InviteUserRequestDto
    {        
        private string _emailId;
        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Organization name is required")]
        public string OrgName { get; set; } = string.Empty;

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string EmailId
        {
            get => _emailId;
            set => _emailId = value?.Trim().ToLowerInvariant() ?? string.Empty;
        }

        [Required(ErrorMessage = "Role is required")]
        public RoleName Role { get; set; }
    }

}
