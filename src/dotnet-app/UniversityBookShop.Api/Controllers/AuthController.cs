using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Common.Constants;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.Api;

namespace UniversityBookShop.Api.Controllers
{
    [ApiController]
    [Route(ApiConstants.Routing.ApiController)]
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        private readonly IIdentityServerClient _identityServerClient;

        public AuthController(IIdentityServerClient identityServerClient)
        {
            _identityServerClient = identityServerClient;
        }

        [HttpPost(ApiConstants.Routing.Auth.ByUsernameAndPassword)]
        public async Task<IActionResult> LoginByUsernameAndPassword([FromBody] LoginByUserNameAndPassword model, CancellationToken cancellationToken)
        {
            //return Ok(await Mediator.Send(query, cancellationToken));
            var token = await _identityServerClient.GetApiToken(model);
            return Ok(token);
        }
    }
}
