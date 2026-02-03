using AMLRS.Core.Domains.Users.Enums;

namespace AMLRS.Application.DTOs
{
    public class UsertblDto
    {
        public int UserdtoId { get; set; }
        public string OrgName { get; set; } 
        public string Name { get; set; } 
        public string EmailId { get; set; } 
        public RoleName Role { get; set; } 
    }
}
