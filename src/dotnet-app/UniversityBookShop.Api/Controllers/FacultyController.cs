using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Common.Models;
using UniversityBookShop.Application.Cqrs.Faculties.Commands.Create;
using UniversityBookShop.Application.Cqrs.Faculties.Commands.Update;
using UniversityBookShop.Application.Cqrs.Faculties.Queries.GetFaculties;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Api.Controllers
{
    [Route("api/[controller]")]
    public class FacultyController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<FacultyDto>>> GetAll([FromQuery] PaginationParams paginationParams)
        {
            var query = new GetAllFacultiesQuery() { PaginationParams = paginationParams };
            var vm = await Mediator.Send(query);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize((PaginationMetadata)vm));
            return Ok(vm.Items);
        }

        [HttpGet("{universityId}")]
        public async Task<ActionResult<List<FacultyDto>>> GetByUniversityId([FromQuery] PaginationParams paginationParams, int universityId)
        {
            var query = new GetFacultiesByUniversityIdQuery() { PaginationParams = paginationParams, UniversityId = universityId };
            var vm = await Mediator.Send(query);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize((PaginationMetadata)vm));
            return vm != null ? Ok(vm.Items): BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateFacultyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFacultyCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteFacultyCommand() { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}