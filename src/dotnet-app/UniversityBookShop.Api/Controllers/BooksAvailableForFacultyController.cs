using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Commands.Create;
using UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Commands.Delete;
using UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Queries.Get;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Api.Controllers
{
    [Route("api/[controller]")]
    public class BooksAvailableForFacultyController : BaseController
    {
        /// <summary>
        /// Get all books available to all faculties.
        /// </summary>
        /// <param name="paginationParams"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<BooksAvailableForFacultyDto>>>> GetAll([FromQuery] PaginationParams paginationParams)
        {
            var vm = await Mediator.Send(new GetAllBooksAvailableForFacultyWithPaginationQuery()
            {
                PageIndex = paginationParams.PageIndex,
                PageSize = paginationParams.PageSize
            });

            return Ok(vm);
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


