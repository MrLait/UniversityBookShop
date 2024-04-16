namespace Identity.Api.Constants
{
    public static class RoutingConstants
    {
        public const string ApiController = "api/[controller]";

        public static class User
        {
            public const string Add = "add";
            public const string Update = "update";
            public const string Remove = "remove";
            public const string GetAll = "all";
            public const string ControllerName = "users";
            public const string ChangePassword = "changepassword";
        }

        public const string ControllerName = "roles";
        public const string AddToRole = "addtorole";
        public const string AddToRoles = "addtoroles";
        public const string RemoveFromRole = "removefromrole";
        public const string RemoveFromRoles = "removefromroles";
    }
}
