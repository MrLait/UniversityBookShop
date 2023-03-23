using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Cqrs.BooksPurchasedByUniversities.Queries.Get;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Api.Controllers
{
    [Route("api/[controller]")]
    public class BooksPurchasedByUniversityController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<BooksPurchasedByUniversityDto>>> GetAll()
        {
            var vm = await Mediator.Send(new GetAllBooksPurchasedByUniversityQuery());
            return Ok(vm);
        }

        [HttpGet("{bookId}/{universityId}")]
        public async Task<ActionResult<bool>> GetIsBookAtUniversity(int bookId, int universityId)
        {
            var vm = await Mediator.Send(new GetIsBookAtUniversityQuery() { BookId = bookId, UniversityId = universityId });
            return Ok(vm);
        }
    }
}
