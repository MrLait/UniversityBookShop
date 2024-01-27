using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Cqrs.Universities.Commands.Create;
using UniversityBookShop.Application.Cqrs.Universities.Commands.Delete;
using UniversityBookShop.Application.Cqrs.Universities.Commands.Update;
using UniversityBookShop.Application.Cqrs.Universities.Queries.Get;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Api.Controllers;

[Route("api/[controller]")]
public class UniversityController : BaseController
{
    /// <summary>
    /// Get all universities. //ToDo check query method
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<ServiceResult<List<UniversityDto>>>> GetAll([FromQuery] PaginationParams paginationParams)
    {
        var vm = await Mediator.Send(new GetAllUniversitiesWithPaginationQuery()
        {
            PageIndex =  paginationParams.PageIndex,
            PageSize = paginationParams.PageSize,
        });

        return Ok(vm);
    }

    /// <summary>
    /// Get university by university id.
    /// </summary>
    [HttpGet("{universityId}")]
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
    public async Task<ActionResult<int>> Create(CreateUniversityCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    /// <summary>
    /// Update university.
    /// </summary>
    [HttpPut]
    public async Task<IActionResult> Update(UpdateUniversityCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Delete university.
    /// </summary>
    [HttpDelete("{id}")]
    [SwaggerResponse(StatusCodes.Status204NoContent)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteUniversityCommand() { Id = id });
        return NoContent();
    }
}
