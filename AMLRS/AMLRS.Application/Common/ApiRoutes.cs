namespace AMLRS.Application.Common
{
    public static class ApiRoutes
    {
        public const string Login = "login";
        public const string AddOrganisation = "addOrganisation";
        public const string AddOrgadmin = "addOrgadmin";
        public const string GetAllOrg = "organisations";
        public const string GetOrgById = "organisation/{id:int}";
        public const string GetAllOrgAdmins = "orgAdmins";
        public const string GetOrgAdminById = "orgAdmin/{id:int}";
    }
}
