namespace AMLRS.Application.Common
{
    public static class ApiRoutes
    {
        public const string Login = "login";
        public const string SignUp = "signup";
        public const string VerifyToken = "verify_token";
        public const string AddOrganisation = "add_organisation";
        public const string AddOrgadmin = "add_admin";
        public const string GetAllOrg = "get_organisations";
        public const string GetOrgById = "get_organisation/{id:int}";
        public const string GetAllOrgAdmins = "get_admins";
        public const string GetOrgAdminById = "get_admin/{id:int}";

        public const string Invite = "invite";
        public const string VerifyLoginOtp = "verify_otp_login";
        public const string VerifyRegOtp = "verify_otp_signup";

        public const string Update_admin = "api/update_admin/{id:int}";
        public const string Update_organisation = "api/update_organisation/{id:int}";
        public const string Update_user = "api/update_user/{id:int}";

        public const string Delete_admin = "api/delete_admin/{id:int}";
        public const string Delete_organisation = "api/delete_organisation/{id:int}";
        public const string Delete_user = "api/delete_user/{id:int}";
    }
}
