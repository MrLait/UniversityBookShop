using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Cqrs.Faculties.Commands.Create;
using UniversityBookShop.Application.Cqrs.Faculties.Commands.Update;
using UniversityBookShop.Application.Cqrs.Faculties.Queries.GetFaculties;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Api.Controllers
{
    [Route("api/[controller]")]
    public class FacultyController : BaseController
    {
        /// <summary>
        /// Get all Faculties.
        /// </summary>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceResult<List<FacultyDto>>>> GetAll([FromQuery] PaginationParams paginationParams)
        {
            var query = new GetAllFacultiesWithPaginationQuery(paginationParams);
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        /// <summary>
        /// Get all faluties by university id.
        /// </summary>
        [HttpGet("{universityId}")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<FacultyDto>>> GetByUniversityId([FromQuery] PaginationParams paginationParams, int universityId)
        {
            var vm = await Mediator.Send(new GetFacultiesByUniversityIdQuery(paginationParams) 
            { 
                UniversityId = universityId,
            });

            return Ok(vm);
        }

        /// <summary>
        /// Create faculty.
        /// </summary>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Create([FromBody] CreateFacultyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Update faculty.
        /// </summary>
        [HttpPut]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(UpdateFacultyCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete faculty by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteFacultyCommand() { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}