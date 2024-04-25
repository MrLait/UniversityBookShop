using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Json;
using UniversityBookShop.Application.Common.Constants;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.Api;
using UniversityBookShop.Application.Common.Models.Auth;
using UniversityBookShop.Application.Common.Models.ServicesModels;
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

        public async Task<ServiceResult<Token>> GetApiToken(LoginByUserNameAndPassword options)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new("scope", options.Scope),
                new("username", options.UserName),
                new("password", options.Password),
                new("grant_type", options.GrantType),
                new("client_id", options.ClientId)
            };

            var content = new FormUrlEncodedContent(keyValues);
            var response = await HttpClient.PostAsync("/connect/token", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var tokenError = JsonConvert.DeserializeObject<TokenError>(responseContent);
                var errorMessage = $"Error: {tokenError.Error ?? "empty"}; Error descriptions: {tokenError.ErrorDescription??"empty"};";
                return ServiceResult.Failed<Token>(ServiceError.CustomMessage(errorMessage, ApplicationConstants.Service.StatusCode.Validation));
            }
            var token = JsonConvert.DeserializeObject<Token>(responseContent);
            return token.AccessToken != null ? ServiceResult.Success(token) : ServiceResult.Failed(token, ServiceError.NotFound);
        }
    }
}