using Identity.Application.Common.Constants;
using Identity.Application.Common.Models.Responses;
using IdentityServer.Application.Common.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Client.HttpClients.IdentityApi
{
    public class RoleClient : IdentityApiBaseClient, IRoleClient
    {
        public RoleClient(HttpClient httpClient, IOptions<ServiceAdressOptions> options) : base(httpClient, options) { }

        public async Task<IdentityResult> Add(IdentityRole role)
            => await SendPostRequest(role, $"/{ApiConstants.Routing.Role.ControllerApiName}/{ApiConstants.Routing.Role.Add}");

        public async Task<IdentityApiResponse<IdentityRole>> Get(string name)
            => await SendGetRequest<IdentityRole>($"{ApiConstants.Routing.Role.ControllerApiName}?name={name}");

        public async Task<IdentityApiResponse<IEnumerable<IdentityRole>>> GetAll()
            => await SendGetRequest<IEnumerable<IdentityRole>>($"/{ApiConstants.Routing.Role.ControllerApiName}/{ApiConstants.Routing.Role.GetAll}");

        public async Task<IdentityResult> Remove(IdentityRole role)
            => await SendPostRequest(role, $"/{ApiConstants.Routing.Role.ControllerApiName} / {ApiConstants.Routing.Role.Remove}");

        public async Task<IdentityResult> Update(IdentityRole role)
            => await SendPostRequest(role, $"/{ApiConstants.Routing.Role.ControllerApiName} / {ApiConstants.Routing.Role.Update}");
    }
}