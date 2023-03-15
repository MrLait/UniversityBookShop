using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Cqrs.PurchasedBookFaculty.Queries.Get;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Api.Controllers;

[Route("api/[controller]")]
public class PurchasedBookFaculty : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<PurchasedBookFacultyDto>>> GetAll()
    {
        var vm = await Mediator.Send(new GetAllPurchasedBooksFaculty());
        return Ok(vm);
    }
}
