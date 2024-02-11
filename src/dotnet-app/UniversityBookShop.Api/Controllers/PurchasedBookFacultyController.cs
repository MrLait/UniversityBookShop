using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Api.Constants;
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
[Route(RoutingConstants.ApiController)]
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
    [HttpGet(RoutingConstants.PurchasedBookFaculty.FacultyId)]
    public async Task<ActionResult<ServiceResult<PaginatedList<PurchasedBookByFacultyIdVm>>>> GetByFacultyId(int facultyId, [FromQuery] PaginationParams paginationParams)
    {
        var query = new GetPurchasedBooksByFacultyIdWithPaginationQuery(paginationParams, facultyId);
        return Ok(await Mediator.Send(query));
    }

    /// <summary>
    /// Retrieves a paginated list of purchased books for a university by its ID.
    /// </summary>
    [HttpGet(RoutingConstants.PurchasedBookFaculty.UniversityId)]
    public async Task<ActionResult<ServiceResult<PaginatedList<PurchasedBookFacultyDto>>>> GetByUniversityId(int universityId, [FromQuery] PaginationParams paginationParams)
    {
        var query = new GetPurchasedBooksByUniversityIdWithPaginationQuery(paginationParams, universityId);
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
    /// Delete a purchased book entry for a faculty by its ID.
    /// </summary>
    [HttpDelete(RoutingConstants.Id)]
    public async Task<ActionResult<ServiceResult<Unit>>> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeletePurchasedBookFacultyCommand { Id = id }));
    }

    /// <summary>
    /// Delete a purchased book by faulctyId and bookId.
    /// </summary>
    [HttpDelete(RoutingConstants.PurchasedBookFaculty.FacultyIdAndBookId)]
    public async Task<ActionResult<ServiceResult<Unit>>> Delete(int facultyId, int bookId)
    {
        return Ok(await Mediator.Send(new DeletePurchasedBookByFacultyIdAndBookIdCommand(facultyId, bookId)));
    }
}
