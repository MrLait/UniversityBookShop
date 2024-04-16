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
            => await SendPostRequest(role, $"/{RoutingConstants.Role.ControllerApiName}/{RoutingConstants.Role.Add}");

        public async Task<IdentityApiResponse<IdentityRole>> Get(string name)
            => await SendGetRequest<IdentityRole>($"{RoutingConstants.Role.ControllerApiName}?name={name}");

        public async Task<IdentityApiResponse<IEnumerable<IdentityRole>>> GetAll()
            => await SendGetRequest<IEnumerable<IdentityRole>>($"/{RoutingConstants.Role.ControllerApiName}/{RoutingConstants.Role.GetAll}");

        public async Task<IdentityResult> Remove(IdentityRole role)
            => await SendPostRequest(role, $"/{RoutingConstants.Role.ControllerApiName}/{RoutingConstants.Role.Remove}");

        public async Task<IdentityResult> Update(IdentityRole role)
            => await SendPostRequest(role, $"/{RoutingConstants.Role.ControllerApiName}/{RoutingConstants.Role.Update}");
    }
}