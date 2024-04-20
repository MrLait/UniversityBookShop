using AutoMapper;
using MediatR;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models.Api;
using UniversityBookShop.Application.Common.Models.Auth;
using UniversityBookShop.Application.Common.Models.ServicesModels;

namespace UniversityBookShop.Application.Cqrs.Auths.Queries.Get
{
    public class LoginByUserNameAndPasswordQuery:
        IRequest<ServiceResult<Token>>, IMapWith<LoginByUserNameAndPassword>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoginByUserNameAndPasswordQuery, LoginByUserNameAndPassword>();
        }
    }

    public class LoginByUserNameAndPasswordQueryHandler :
        IRequestHandler<LoginByUserNameAndPasswordQuery,
            ServiceResult<Token>>
{
        private readonly IIdentityServerClient _identityServerClient;
        private readonly IMapper _mapper;

        public LoginByUserNameAndPasswordQueryHandler(IIdentityServerClient identityServerClient, IMapper mapper) =>
            (_identityServerClient, _mapper) = (identityServerClient, mapper);

        public async Task<ServiceResult<Token>> Handle(LoginByUserNameAndPasswordQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<LoginByUserNameAndPassword>(request);
            var token = await _identityServerClient.GetApiToken(entity);
            return token;
        }
    }
}
