using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Common.Constants;
using UniversityBookShop.Application.Cqrs.Auths.Queries.Get;

namespace UniversityBookShop.Api.Controllers
{
    [ApiController]
    [Route(ApiConstants.Routing.ApiController)]
    [AllowAnonymous]
    public class AuthController : BaseController
    {

        [HttpPost(ApiConstants.Routing.Auth.ByUsernameAndPassword)]
        public async Task<IActionResult> LoginByUsernameAndPassword([FromBody] LoginByUserNameAndPasswordQuery query, CancellationToken cancellationToken)
        {
            var vm = await Mediator.Send(query, cancellationToken);
            return Ok(vm);
        }
    }
}
