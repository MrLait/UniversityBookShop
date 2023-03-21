using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Commands.Create;
using UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Commands.Delete;
using UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Queries.Get;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Api.Controllers
{
    [Route("api/[controller]")]
    public class BooksAvailableForFacultyController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<BooksAvailableForFacultyDto>>> GetAll()
        {
            var vm = await Mediator.Send(new GetAllBooksAvailableForFacultyQuery());
            return Ok(vm);
        }

        [HttpPost("purchase/")]
        public async Task<ActionResult<int>> Create(PurchaseBooksAvailableForFacultyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("add/")]
        public async Task<ActionResult<int>> Create(AddBooksAvailableForFacultyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteBooksAvailableForFacultyCommand() { Id = id }));
        }
    }
}


