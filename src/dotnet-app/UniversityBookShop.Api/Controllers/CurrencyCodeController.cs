using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Common.Models;
using UniversityBookShop.Application.Cqrs.CurrencyCodes.Queries.Get;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Api.Controllers;

[Route("api/[controller]")]
public class CurrencyCodeController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<ServiceResult<List<CurrencyCodeDto>>>> GetAll()
    {
        var vm = await Mediator.Send(new GetAllCurrencyCodesQuery());
        return Ok(vm);
    }
}
