namespace AMLRS.Application.Common
{
    public static class ApiRoutes
    {
        public const string Login = "login";
        public const string SignUp = "signup";
        public const string AddOrganisation = "add_organisation";
        public const string AddOrgadmin = "add_admin";
        public const string GetAllOrg = "get_organisations";
        public const string GetOrgById = "get_organisation/{id:int}";
        public const string GetAllOrgAdmins = "get_admins";
        public const string GetOrgAdminById = "get_admin/{id:int}";
        public const string Invite = "invite";
        public const string VerifyLoginOtp = "verify_otp_login";
        public const string VerifyRegOtp = "verify_otp_signup";
    }
}
