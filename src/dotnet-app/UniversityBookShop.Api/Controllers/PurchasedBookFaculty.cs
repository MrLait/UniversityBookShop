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
        var vm = await Mediator.Send(new GetAllPurchasedBooksFacultyQuery());
        return Ok(vm);
    }

    [HttpGet("{facultyId}")]
    public async Task<ActionResult<List<PurchasedBookByFacultyIdVm>>> GetAll(int facultyId)
    {
        var vm = await Mediator.Send(new GetPurchasedBooksByFacultyIdQuery() { FacultyId = facultyId });
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
