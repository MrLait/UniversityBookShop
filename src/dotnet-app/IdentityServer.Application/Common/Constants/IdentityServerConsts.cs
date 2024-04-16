namespace IdentityServer.Application.Common.Constants
{
    public static class IdentityServerConsts
    {
        public const string ApiScope = "OnlineShop.Api";
        public const string WebScope = "OnlineShop.Web";

        public const string GrantType_ClientCredentials = "client_credentials";
        public const string GrantType_Password = "password";
        public const string IdentityIssuer = "IDENTITY_ISSUER";
        
        public static class Connections
        {
            public const string IdentityConnection = "IdentityConnection";
            public const string IdentityServerConnection = "IdentityServerConnection";
        }
    }
}
