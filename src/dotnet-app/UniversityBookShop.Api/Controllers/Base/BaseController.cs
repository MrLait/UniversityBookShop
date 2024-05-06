using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Api.Controllers.Base;

[ApiController]
[Route(ApiConstants.Routing.ApiControllerAction)]
public class BaseController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator =>
        _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
