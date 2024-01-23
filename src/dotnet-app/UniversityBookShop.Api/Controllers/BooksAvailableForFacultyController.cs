using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Common.Models;
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
        public async Task<ActionResult<List<BooksAvailableForFacultyDto>>> GetAll([FromQuery] PaginationParams paginationParams)
        {
            var vm = await Mediator.Send(new GetAllBooksAvailableForFacultyQuery() { PaginationParams = paginationParams });
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize((PaginationMetadata)vm));
            return Ok(vm.Items);
        }

        [HttpGet("{facultyId}")]
        public async Task<ActionResult<List<BooksAvailableForFacultyDto>>> GetByFacultyId(int facultyId)
        {
            var vm = await Mediator.Send(new GetAvailableBooksByFacultyIdQuery() { FacultyId = facultyId });
            return Ok(vm);
        }

        [HttpGet("{facultyId}/{bookId}")]
        public async Task<ActionResult<BooksAvailableForFacultyDto>> GetByFacultyIdAndBookId(int facultyId, int bookId)
        {
            var vm = await Mediator.Send(new GetAvailableBooksByFacultyIdAndBookIdQuery() { FacultyId = facultyId, BookId = bookId });
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


