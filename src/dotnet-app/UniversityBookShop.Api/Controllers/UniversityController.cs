using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Cqrs.Universities.Commands.Create;
using UniversityBookShop.Application.Cqrs.Universities.Commands.Delete;
using UniversityBookShop.Application.Cqrs.Universities.Commands.Update;
using UniversityBookShop.Application.Cqrs.Universities.Queries.Get;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Api.Controllers;

[Route("api/[controller]")]
public class UniversityController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<UniversityDto>>> GetAll()
    {
        var vm = await Mediator.Send(new GetAllUniversitiesQuery());
        return Ok(vm);
    }

    [HttpGet("{universityId}")]
    public async Task<ActionResult<UniversityDto>> GetAll(int universityId)
    {
        var vm = await Mediator.Send(new GetUniversityByUniversityIdQuery() { UniversityId = universityId });
        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateUniversityCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateUniversityCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteUniversityCommand() { Id = id });
        return NoContent();
    }
}
