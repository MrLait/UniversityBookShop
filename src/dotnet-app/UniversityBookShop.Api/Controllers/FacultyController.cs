using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Api.Controllers.Base;
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
        public async Task<ActionResult<List<FacultyDto>>> GetAll()
        {
            var query = new GetAllFacultiesQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
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