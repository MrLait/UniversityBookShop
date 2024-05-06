using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Api.Controllers
{
    [ApiController]
    [Route(ApiConstants.Routing.ApiController)]
    [AllowAnonymous]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public string Check() => "Service is online";
    }
}
