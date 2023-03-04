using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UniversityBookShop.Api.Controllers.Base;

[ApiController]
[Route("api/[controller]/[action]")]
public class BaseController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator =>
        _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
