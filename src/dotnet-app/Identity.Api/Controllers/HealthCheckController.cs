using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [AllowAnonymous]
    public class HealthCheckController:ControllerBase
    {
        [HttpGet]
        public string Get() => "Service is online";
    }
}
