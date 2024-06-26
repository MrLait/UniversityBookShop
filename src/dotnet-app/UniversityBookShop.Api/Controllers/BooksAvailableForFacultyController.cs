using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Common.Constants;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Commands.Create;
using UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Commands.Delete;
using UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Queries.Get;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Api.Controllers
{
    [ApiController]
    [Route(ApiConstants.Routing.ApiController)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BooksAvailableForFacultyController : BaseController
    {
        /// <summary>
        /// Get all available books to all faculties.
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ServiceResult<PaginatedList<BooksAvailableForFacultyDto>>>> GetAll([FromQuery] PaginationParams paginationParams)
        {
            var query = new GetAllBooksAvailableForFacultyWithPaginationQuery(paginationParams);
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Get all available books by faculty id. 
        /// </summary>
        [AllowAnonymous]
        [HttpGet(ApiConstants.Routing.BooksAvailableForFaculty.FacultyId)]
        public async Task<ActionResult<ServiceResult<PaginatedList<BooksAvailableForFacultyDto>>>> GetByFacultyId(int facultyId, [FromQuery] PaginationParams paginationParams)
        {
            var query = new GetAvailableBooksByFacultyIdWithPaginationQuery(facultyId, paginationParams);
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Get all available books by faculty id and book id. 
        /// </summary>
        [AllowAnonymous]
        [HttpGet(ApiConstants.Routing.BooksAvailableForFaculty.FacultyIdBookId)]
        public async Task<ActionResult<ServiceResult<BooksAvailableForFacultyDto>>> GetByFacultyIdAndBookId(int facultyId, int bookId)
        {
            var query = new GetAvailableBooksByFacultyIdAndBookIdQuery(facultyId, bookId);
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Add a book for a faculty.
        /// </summary>
        [HttpPost(ApiConstants.Routing.BooksAvailableForFaculty.Add)]
        public async Task<ActionResult<ServiceResult<int>>> Create(AddBooksAvailableForFacultyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Remove a book for a faculty.
        /// </summary>
        [HttpDelete(ApiConstants.Routing.Id)]
        public async Task<ActionResult<ServiceResult<int>>> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteBooksAvailableForFacultyCommand() { Id = id }));
        }
    }
}


