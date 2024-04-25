using Identity.Application.Common.Dtos;
using Identity.Application.Common.Models.Responses;
using IdentityServer.Application.Common.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Client.HttpClients.IdentityApi
{
    public abstract class IdentityApiBaseClient : IDisposable
    {
        public IdentityApiBaseClient(HttpClient client, IOptions<ServiceAdressOptions> options)
        {
            HttpClient = client;
            HttpClient.BaseAddress = new Uri(options.Value.IdentityApi);
        }

        public HttpClient HttpClient { get; init; }

        protected async Task<IdentityResult> SendPostRequest<TRequest>(TRequest request, string path)
        {
            var jsonContent = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var requestResult = await HttpClient.PostAsync(path, httpContent);

            IdentityResult result;

            if (requestResult.IsSuccessStatusCode)
            {
                var responseJson = await requestResult.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<IdentityResultDto>(responseJson);
                result = HandleResponse(response);
            }
            else
            {
                result = IdentityResult.Failed(
                    new IdentityError()
                    {
                        Code = requestResult.StatusCode.ToString(),
                        Description = requestResult.ReasonPhrase
                    }
                );
            }

            return result;
        }

        protected async Task<IdentityApiResponse<TResult>> SendGetRequest<TResult>(string request)
        {
            var requestResult = await HttpClient.GetAsync(request);

            IdentityApiResponse<TResult> result;

            if (requestResult.IsSuccessStatusCode)
            {
                var response = await requestResult.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(response))
                {
                    result = new IdentityApiResponse<TResult>()
                    {
                        Code = requestResult.StatusCode.ToString(),
                        Description = requestResult.ReasonPhrase
                    };
                }
                else
                {
                    var payload = JsonConvert.DeserializeObject<TResult>(response);
                    result = new IdentityApiResponse<TResult>()
                    {
                        Code = requestResult.StatusCode.ToString(),
                        Description = requestResult.ReasonPhrase,
                        Payload = payload
                    };
                }
            }
            else
            {
                result = new IdentityApiResponse<TResult>()
                {
                    Code = requestResult.StatusCode.ToString(),
                    Description = requestResult.ReasonPhrase
                };
            }

            return result;
        }

        public void Dispose()
        {
            HttpClient.Dispose();
        }

        private IdentityResult HandleResponse(IdentityResultDto response)
        {
            if (response.Succeeded)
            {
                return IdentityResult.Success;
            }
            else
            {
                return IdentityResult.Failed(response.Errors.ToArray());
            }
        }
    }
}