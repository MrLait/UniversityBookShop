namespace Identity.Application.Common.Constants
{
    public static class ApiConstants
    {
        public static class DbConnection
        {
            public const string Identity = "IdentityConnection";
        }

        public static class Policy
        {
            public const string ApiScope = "ApiScope";
        }

        public static class Identity
        {
            public const string IdentityAuthority = "IDENTITY_AUTHORITY";
            public const string ApiScope = "Api";
            public const string ClaimTypeScope = "scope";
        }

        public static class Routing
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

        public static class Swagger
        {
            /// <summary>
            /// Version.
            /// </summary>
            public const string Version = "v1";

            /// <summary>
            /// Name.
            /// </summary>
            public const string Name = "Identity API " + Version;

            /// <summary>
            /// String url.
            /// </summary>
            public const string Url = "/swagger/v1/swagger.json";
        }
    }
}
