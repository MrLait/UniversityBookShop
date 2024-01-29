using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Commands.Create;
using UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Commands.Delete;
using UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Queries.Get;
using UniversityBookShop.Application.Dto;
using UniversityBookShop.Application.Dto.Vm;

namespace UniversityBookShop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PurchasedBookFacultyController : BaseController
{
    /// <summary>
    /// Retrieves a paginated list of all books purchased by faculties.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<ServiceResult<PaginatedList<PurchasedBookFacultyDto>>>> GetAll([FromQuery] PaginationParams paginationParams)
    {
        var query = new GetAllPurchasedBooksFacultyWithPaginationQuery(paginationParams);
        return Ok(await Mediator.Send(query));
    }

    /// <summary>
    /// Retrieves a paginated list of purchased books specific to a faculty by its ID.
    /// </summary>
    [HttpGet("faculty/{id}")]
    public async Task<ActionResult<ServiceResult<PaginatedList<PurchasedBookByFacultyIdVm>>>> GetByFacultyId(int id, [FromQuery] PaginationParams paginationParams)
    {
        var query = new GetPurchasedBooksByFacultyIdWithPaginationQuery(paginationParams, id);
        return Ok(await Mediator.Send(query));
    }

    /// <summary>
    /// Retrieves a paginated list of purchased books for a university by its ID.
    /// </summary>
    [HttpGet("university/{id}")]
    public async Task<ActionResult<ServiceResult<PaginatedList<PurchasedBookFacultyDto>>>> GetByUniversityId(int id, [FromQuery] PaginationParams paginationParams)
    {
        var query = new GetPurchasedBooksByUniversityIdWithPaginationQuery(paginationParams, id);
        return Ok(await Mediator.Send(query));
    }

    /// <summary>
    /// Purchases a book for a faculty.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<ServiceResult<int>>> Create(CreatePurchasedBooksFacultyCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    /// <summary>
    /// Deletes a purchased book entry for a faculty by its ID.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeletePurchasedBookFacultyCommand { Id = id });
        return NoContent();
    }
}
