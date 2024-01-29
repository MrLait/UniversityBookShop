using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
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
        /// <summary>
        /// Get all books with pagination.
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad reques.Validation exception.</response>
        /// <response code="404">Resoure not found</response>
        /// <response code="500">Server error</response>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceResult<PaginatedList<BookDto>>>> GetAll([FromQuery] PaginationParams paginationParams)
        {
            var vm = await Mediator.Send(new GetAllBooksWithPaginationQuery(paginationParams));
            return Ok(vm);
        }

        /// <summary>
        /// Create new book.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateBookCommand command)
        {
            return Ok(await Mediator.Send(command));

        }

        /// <summary>
        /// Update an existing book.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBookCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete book.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteBookCommand() { Id = id });
            return NoContent();
        }
    }
}
