namespace Identity.Application.Common.Constants
{
    public static class RoutingConstants
    {
        public const string Api = "api";
        public const string ApiController = $"{Api}/[controller]";

        public static class User
        {
            public const string Add = "add";
            public const string Update = "update";
            public const string Remove = "remove";
            public const string GetAll = "all";
            public const string ChangePassword = "changepassword";

            public const string ControllerName = "user";
            public const string ControllerApiName = $"{Api}/{ControllerName}";
        }

        public static class Role
        {
            public const string ControllerName = "role";
            public const string ControllerApiName = $"{Api}/{ControllerName}";
            public const string Add = "add";
            public const string Update = "update";
            public const string Remove = "remove";
            public const string GetAll = "all";
        }

        public const string AddToRole = "addtorole";
        public const string AddToRoles = "addtoroles";
        public const string RemoveFromRole = "removefromrole";
        public const string RemoveFromRoles = "removefromroles";
    }
}
