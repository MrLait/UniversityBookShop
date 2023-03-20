using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Cqrs.BooksAvailableForFaculty.Queries.Get;
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
        // [HttpPost]
        // public async Task<ActionResult<int>> Create(PurchaseBooksAvailableForFacultyCommand command)
        // {
        //     return Ok(await Mediator.Send(command));
        // }

        // [HttpPost]
        // public async Task<ActionResult<int>> Create(AddBooksAvailableForFacultyCommand command)
        // {
        //     return Ok(await Mediator.Send(command));
        // }

    }
}


