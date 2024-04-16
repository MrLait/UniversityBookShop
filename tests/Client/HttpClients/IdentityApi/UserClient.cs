using Identity.Application.Common.Constants;
using Identity.Application.Common.Models.Requests;
using Identity.Application.Common.Models.Responses;
using Identity.Domain.Models;
using IdentityServer.Application.Common.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Client.HttpClients.IdentityApi
{
    public class UserClient : IdentityApiBaseClient, IUserClient
    {
        public UserClient(HttpClient httpClient, IOptions<ServiceAdressOptions> options) : base(httpClient, options) { }

        public async Task<IdentityResult> Add(CreateUserRequest request)
            => await SendPostRequest(request, $"/{RoutingConstants.User.ControllerApiName}/{RoutingConstants.User.Add}");

        public async Task<IdentityResult> ChangePassword(UserPasswordChangeRequest request)
            => await SendPostRequest(request, $"/{RoutingConstants.User.ControllerApiName}/{RoutingConstants.User.ChangePassword}");

        public async Task<IdentityResult> AddToRole(AddRemoveRoleRequest request)
            => await SendPostRequest(request, $"/{RoutingConstants.User.ControllerApiName}/{RoutingConstants.AddToRole}");

        public async Task<IdentityResult> AddToRoles(AddRemoveRolesRequest request)
            => await SendPostRequest(request, $"/{RoutingConstants.User.ControllerApiName}/{RoutingConstants.AddToRoles}");

        public async Task<IdentityResult> RemoveFromRole(AddRemoveRoleRequest request)
            => await SendPostRequest(request, $"/{RoutingConstants.User.ControllerApiName}/{RoutingConstants.RemoveFromRole}");

        public async Task<IdentityResult> RemoveFromRoles(AddRemoveRolesRequest request)
            => await SendPostRequest(request, $"/{RoutingConstants.User.ControllerApiName}/{RoutingConstants.RemoveFromRoles}");

        public async Task<IdentityApiResponse<ApplicationUser>> Get(string name)
            => await SendGetRequest<ApplicationUser>($"{RoutingConstants.User.ControllerApiName}?name={name}");

        public async Task<IdentityApiResponse<IEnumerable<ApplicationUser>>> GetAll()
            => await SendGetRequest<IEnumerable<ApplicationUser>>($"/{RoutingConstants.User.ControllerApiName}/{RoutingConstants.User.GetAll}");

        public async Task<IdentityResult> Remove(ApplicationUser user)
            => await SendPostRequest(user, $"/{RoutingConstants.User.ControllerApiName}/{RoutingConstants.User.Remove}");

        public async Task<IdentityResult> Update(ApplicationUser user)
            => await SendPostRequest(user, $"/{RoutingConstants.User.ControllerApiName}/{RoutingConstants.User.Update}");
    }
}