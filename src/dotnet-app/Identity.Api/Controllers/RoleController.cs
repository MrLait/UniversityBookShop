using Identity.Application.Common.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.UserManagementService.Controllers
{
    [ApiController]
    [Route(ApiConstants.Routing.ApiController)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost(ApiConstants.Routing.Role.Add)]
        public Task<IdentityResult> Add(IdentityRole role)
        {
            var result = _roleManager.CreateAsync(role);
            return result;
        }

        [HttpPost(ApiConstants.Routing.Role.Update)]
        public async Task<IdentityResult> Update(IdentityRole role)
        {
            var roleToBeUpdated = await _roleManager.FindByIdAsync(role.Id);
            if (roleToBeUpdated == null)
                return IdentityResult.Failed(new IdentityError() { Description = $"Role {role.Name} was not found." });

            roleToBeUpdated.Name = role.Name;

            var result = await _roleManager.UpdateAsync(roleToBeUpdated);
            return result;
        }

        [HttpPost(ApiConstants.Routing.Role.Remove)]
        public Task<IdentityResult> Remove(IdentityRole role)
        {
            var result = _roleManager.DeleteAsync(role);
            return result;
        }

        [HttpGet]
        public Task<IdentityRole> Get(string name)
        {
            var result = _roleManager.FindByNameAsync(name);
            return result;
        }

        [HttpGet(ApiConstants.Routing.Role.GetAll)]
        public IEnumerable<IdentityRole> Get()
        {
            var result = _roleManager.Roles.AsEnumerable();
            return result;
        }
    }
}