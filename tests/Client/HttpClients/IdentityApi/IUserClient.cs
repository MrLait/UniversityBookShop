using Identity.Application.Common.Models.Requests;
using Identity.Application.Common.Models.Responses;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Client.HttpClients.IdentityApi
{
    public interface IUserClient
    {
        Task<IdentityResult> Add(CreateUserRequest request);

        Task<IdentityResult> Update(ApplicationUser user);

        Task<IdentityResult> Remove(ApplicationUser user);

        Task<IdentityApiResponse<ApplicationUser>> Get(string name);

        Task<IdentityApiResponse<IEnumerable<ApplicationUser>>> GetAll();

        Task<IdentityResult> ChangePassword(UserPasswordChangeRequest request);

        Task<IdentityResult> AddToRole(AddRemoveRoleRequest request);

        Task<IdentityResult> AddToRoles(AddRemoveRolesRequest request);

        Task<IdentityResult> RemoveFromRole(AddRemoveRoleRequest request);

        Task<IdentityResult> RemoveFromRoles(AddRemoveRolesRequest request);
    }
}