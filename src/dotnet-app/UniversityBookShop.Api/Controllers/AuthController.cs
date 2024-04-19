using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityBookShop.Api.Controllers.Base;
using UniversityBookShop.Application.Common.Constants;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.Api;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Api.Controllers
{
    [ApiController]
    [Route(ApiConstants.Routing.ApiController)]
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        private readonly IIdentityServerClient _identityServerClient;
        private readonly IMapper _mapper;

        public AuthController(IIdentityServerClient identityServerClient, IMapper mapper)
        {
            _identityServerClient = identityServerClient;
            _mapper = mapper;
        }

        [HttpPost(ApiConstants.Routing.Auth.ByUsernameAndPassword)]
        public async Task<IActionResult> LoginByUsernameAndPassword([FromBody] LoginByUserNameAndPasswordDto model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<LoginByUserNameAndPassword>(model);
            var token = await _identityServerClient.GetApiToken(entity);
            return Ok(token);
        }
    }
}
