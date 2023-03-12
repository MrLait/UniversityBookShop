using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Cqrs.Books.Commands.Create;
using UniversityBookShop.Application.Cqrs.Books.Commands.Delete;
using UniversityBookShop.Application.Cqrs.Books.Commands.Update;
using UniversityBookShop.Application.Cqrs.Books.Queries.Get;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Api.Controllers
{
    [Route("api/[controller]")]
    public class BookController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetAll()
        {
            var vm = await Mediator.Send(new GetAllBooksQuery());
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateBookCommand command)
        {
            return Ok(await Mediator.Send(command));

        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBookCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteBookCommand() { Id = id });
            return NoContent();
        }
    }
}
