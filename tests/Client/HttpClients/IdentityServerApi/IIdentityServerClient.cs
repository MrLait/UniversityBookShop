using IdentityServer.Application.Common.Models;
using IdentityServer.Application.Common.Options;

namespace Client.HttpClients.IdentityServerApi
{
    public interface IIdentityServerClient
    {
        Task<Token> GetApiToken(IdentityServerApiOptions options);
    }
}