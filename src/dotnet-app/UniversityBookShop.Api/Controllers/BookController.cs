using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Common.Models;
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
        public async Task<ActionResult<List<BookDto>>> GetAll([FromQuery] PaginationParams paginationParams)
        {
            var vm = await Mediator.Send(new GetAllBooksQuery() { PaginationParams = paginationParams });
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize((PaginationMetadata)vm));
            return Ok(vm.Items);
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