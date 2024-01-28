using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Commands.Create;
using UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Commands.Delete;
using UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Queries.Get;
using UniversityBookShop.Application.Dto;
using UniversityBookShop.Application.Dto.Vm;

namespace UniversityBookShop.Api.Controllers;

[Route("api/[controller]")]
public class PurchasedBookFaculty : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<PurchasedBookFacultyDto>>> GetAll()
    {
        var vm = await Mediator.Send(new GetAllPurchasedBooksFacultyWithPaginationQuery());
        return Ok(vm);
    }

    [HttpGet("faculty/{id}")]
    public async Task<ActionResult<List<PurchasedBookByFacultyIdVm>>> GetByFacultyId(int id)
    {
        var vm = await Mediator.Send(new GetPurchasedBooksByFacultyIdQuery() { FacultyId = id });
        return Ok(vm);
    }

    [HttpGet("university/{id}")]
    public async Task<ActionResult<List<PurchasedBookFacultyDto>>> GetByUniversityId(int id)
    {
        var vm = await Mediator.Send(new GetPurchasedBooksByUniversityIdWithPaginationQuery() { UniversityId = id });
        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreatePurchasedBooksFacultyCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeletePurchasedBookFacultyCommand() { Id = id });
        return NoContent();
    }

}
