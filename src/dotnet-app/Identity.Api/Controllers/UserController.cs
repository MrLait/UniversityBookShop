using Identity.Application.Common.Constants;
using Identity.Application.Common.Models.Requests;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [ApiController]
    [Route(ApiConstants.Routing.ApiController)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost(ApiConstants.Routing.User.Add)]
        public Task<IdentityResult> Add(CreateUserRequest request)
        {
            var result = _userManager.CreateAsync(request.User, request.Password);
            return result;
        }

        [HttpPost(ApiConstants.Routing.User.Update)]
        public async Task<IdentityResult> Update(ApplicationUser user)
        {
            var userToBeUpdated = await _userManager.FindByNameAsync(user.UserName);
            if (userToBeUpdated == null)
                return IdentityResult.Failed(new IdentityError() { Description = $"User {user.UserName} was not found." });

            userToBeUpdated.FirstName = user.FirstName;
            userToBeUpdated.LastName = user.LastName;
            userToBeUpdated.PhoneNumber = user.PhoneNumber;
            userToBeUpdated.Email = user.Email;

            var result = await _userManager.UpdateAsync(userToBeUpdated);
            return result;
        }

        [HttpPost(ApiConstants.Routing.User.Remove)]
        public Task<IdentityResult> Remove(ApplicationUser user)
        {
            var result = _userManager.DeleteAsync(user);
            return result;
        }

        [HttpGet]
        public Task<ApplicationUser> Get(string name)
        {
            var result = _userManager.FindByNameAsync(name);
            return result;
        }

        [HttpGet(ApiConstants.Routing.User.GetAll)]
        public IEnumerable<ApplicationUser> Get()
        {
            var result = _userManager.Users.AsEnumerable();
            return result;
        }

        [HttpPost(ApiConstants.Routing.User.ChangePassword)]
        public async Task<IdentityResult> ChangePassword(UserPasswordChangeRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return IdentityResult.Failed(new IdentityError() { Description = $"User {request.UserName} was not found." });

            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            return result;
        }

        [HttpPost(ApiConstants.Routing.AddToRole)]
        public async Task<IdentityResult> AddToRole(AddRemoveRoleRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return IdentityResult.Failed(new IdentityError() { Description = $"User {request.UserName} was not found." });

            var result = await _userManager.AddToRoleAsync(user, request.RoleName);
            return result;
        }

        [HttpPost(ApiConstants.Routing.AddToRoles)]
        public async Task<IdentityResult> AddToRoles(AddRemoveRolesRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return IdentityResult.Failed(new IdentityError() { Description = $"User {request.UserName} was not found." });

            var result = await _userManager.AddToRolesAsync(user, request.RoleNames);
            return result;
        }

        [HttpPost(ApiConstants.Routing.RemoveFromRole)]
        public async Task<IdentityResult> RemoveFromRole(AddRemoveRoleRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return IdentityResult.Failed(new IdentityError() { Description = $"User {request.UserName} was not found." });

            var result = await _userManager.RemoveFromRoleAsync(user, request.RoleName);
            return result;
        }

        [HttpPost(ApiConstants.Routing.RemoveFromRoles)]
        public async Task<IdentityResult> RemoveFromRoles(AddRemoveRolesRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return IdentityResult.Failed(new IdentityError() { Description = $"User {request.UserName} was not found." });

            var result = await _userManager.RemoveFromRolesAsync(user, request.RoleNames);
            return result;
        }
    }
}