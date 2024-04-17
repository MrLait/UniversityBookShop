namespace IdentityServer.Application.Common.Constants
{
    public static class ApiConstants
    {
        public static class IdentityServer
        {
            public const string ApiScope = "Api";
            public const string WebScope = "UniversityBookShop.Api";

            public const string GrantTypeClientCredentials = "client_credentials";
            public const string GrantType_Password = "password";
            public const string IdentityIssuer = "IDENTITY_ISSUER";
        }

        public static class Connection
        {
            public const string Identity = "IdentityConnection";
            public const string IdentityServer = "IdentityServerConnection";
        }

        public static class Routing
        {
            public const string ApiController = "api/[controller]";
        }

        /// <summary>
        /// Swagger constants.
        /// </summary>
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
