using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversityBookShop.Api.Constants;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Cqrs.Universities.Commands.Create;
using UniversityBookShop.Application.Cqrs.Universities.Commands.Delete;
using UniversityBookShop.Application.Cqrs.Universities.Commands.Update;
using UniversityBookShop.Application.Cqrs.Universities.Queries.Get;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Api.Controllers;

[ApiController]
[Route(RoutingConstants.ApiController)]
public class UniversityController : BaseController
{
    /// <summary>
    /// Get all universities.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<ServiceResult<PaginatedList<UniversityDto>>>> GetAll([FromQuery] PaginationParams paginationParams)
    {
        var vm = await Mediator.Send(new GetAllUniversitiesWithPaginationQuery(paginationParams) { PageIndex = paginationParams.PageIndex, PageSize =paginationParams.PageSize});
        return Ok(vm);
    }

    /// <summary>
    /// Get university by university id.
    /// </summary>
    [HttpGet(RoutingConstants.UniversityId)]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ServiceResult<UniversityDto>>> GetAll(int universityId)
    {
        var vm = await Mediator.Send(new GetUniversityByUniversityIdQuery() { UniversityId = universityId });
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
    [HttpDelete(RoutingConstants.Id)]
    public async Task<ActionResult<ServiceResult<Unit>>> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeleteUniversityCommand() { Id = id }));
    }
}
