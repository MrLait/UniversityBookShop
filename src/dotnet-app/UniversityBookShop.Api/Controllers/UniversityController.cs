using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Common.Constants;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Cqrs.Universities.Commands.Create;
using UniversityBookShop.Application.Cqrs.Universities.Commands.Delete;
using UniversityBookShop.Application.Cqrs.Universities.Commands.Update;
using UniversityBookShop.Application.Cqrs.Universities.Queries.Get;
using UniversityBookShop.Application.Dto;
using UniversityBookShop.Application.Dto.Vm;

namespace UniversityBookShop.Api.Controllers;

[ApiController]
[Route(ApiConstants.Routing.ApiController)]
[AllowAnonymous]
public class UniversityController : BaseController
{
    /// <summary>
    /// Get all universities with university pagination.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<ServiceResult<PaginatedList<UniversityDto>>>> GetAll([FromQuery] PaginationParams paginationParams)
    {
        var vm = await Mediator.Send(new GetAllUniversitiesWithPaginationQuery(paginationParams));
        return Ok(vm);
    }

    /// <summary>
    /// Get university by university id with paginated faculties.
    /// </summary>
    [HttpGet(ApiConstants.Routing.University.UniversityId)]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ServiceResult<UniversityWithPaginatedFacultiesVm>>> GetAll(int universityId, [FromQuery] PaginationParams paginationParams)
    {
        var vm = await Mediator.Send(new GetUniversityByUniversityIdWithPaginatedFacultiesQuery(universityId, paginationParams));
        return Ok(vm);
    }

    /// <summary>
    /// Create university.
    /// </summary>
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ServiceResult<int>>> Create(CreateUniversityCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    /// <summary>
    /// Update university.
    /// </summary>
    [HttpPut]
    public async Task<ActionResult<ServiceResult<Unit>>> Update(UpdateUniversityCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    /// <summary>
    /// Delete university.
    /// </summary>
    [HttpDelete(ApiConstants.Routing.Id)]
    public async Task<ActionResult<ServiceResult<Unit>>> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeleteUniversityCommand() { Id = id }));
    }
}
