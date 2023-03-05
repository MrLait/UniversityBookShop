using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Cqrs.Universities.Commands.Create;
namespace UniversityBookShop.Api.Controllers;

[Route("api/[controller]")]
public class UniversityController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<int>> Crate(CreateUniversityCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}
