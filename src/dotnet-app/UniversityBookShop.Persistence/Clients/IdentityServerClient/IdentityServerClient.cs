using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models;
using UniversityBookShop.Application.Common.Models.Api;
using UniversityBookShop.Persistence.Options;

namespace UniversityBookShop.Persistence.Clients.IdentityServerClient
{
    public class IdentityServerClient : IIdentityServerClient
    {
        public IdentityServerClient(HttpClient client, IOptions<ServiceAdressOptions> options)
        {
            HttpClient = client;
            HttpClient.BaseAddress = new Uri(options.Value.IdentityServerApi);
        }

        public HttpClient HttpClient { get; init; }

        public async Task<Token> GetApiToken(LoginByUserNameAndPassword options)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("scope", options.Scope),
                new KeyValuePair<string, string>("username", options.UserName),
                 new KeyValuePair<string, string>("password", options.Password),
                new KeyValuePair<string, string>("grant_type", options.GrantType),
                new KeyValuePair<string, string>("client_id", options.ClientId)
            };

            var content = new FormUrlEncodedContent(keyValues);
            var response = await HttpClient.PostAsync("/connect/token", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            var token = JsonConvert.DeserializeObject<Token>(responseContent);
            return token;
        }
    }
}