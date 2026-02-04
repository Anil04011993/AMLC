namespace AMLRS.Application.Common
{
    public static class ApiRoutes
    {
        public const string Login = "login";
        public const string SignUp = "signup";
        public const string VerifyToken = "verify_token";
        public const string SetPassword = "set_password";
        public const string AddOrganisation = "add_organisation";
        public const string AddOrgadmin = "add_admin";
        public const string GetAllOrg = "get_organisations";
        public const string GetOrgById = "get_organisation/{id:int}";
        public const string GetAllOrgAdmins = "get_admins";
        public const string GetOrgAdminById = "get_admin/{id:int}";

        public const string Invite = "invite";
        public const string VerifyLoginOtp = "verify_otp_login";
        public const string VerifyRegOtp = "verify_otp_signup";

        public const string Update_admin = "update_admin/{id:int}";
        public const string Update_organisation = "update_organisation/{id:int}";
        public const string Update_user = "update_user/{id:int}";

        public const string Delete_admin = "delete_admin/{id:int}";
        public const string Delete_organisation = "delete_organisation/{id:int}";
        public const string Delete_user = "delete_user/{id:int}";
		public const string Getalluser = "get_all_user";
    }
}
