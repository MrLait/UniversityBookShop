using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversityBookShop.Api.Constants;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Cqrs.CurrencyCodes.Queries.Get;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Api.Controllers;

[ApiController]
[Route(RoutingConstants.ApiController)]
public class CurrencyCodeController : BaseController
{
    /// <summary>
    /// Get all currency codes.
    /// </summary>
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ServiceResult<List<CurrencyCodeDto>>>> GetAll()
    {
        var vm = await Mediator.Send(new GetAllCurrencyCodesQuery());
        return Ok(vm);
    }
}
