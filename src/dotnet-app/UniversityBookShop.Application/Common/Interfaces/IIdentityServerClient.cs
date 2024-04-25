using UniversityBookShop.Application.Common.Models.Api;
using UniversityBookShop.Application.Common.Models.Auth;
using UniversityBookShop.Application.Common.Models.ServicesModels;

namespace UniversityBookShop.Application.Common.Interfaces
{
    public interface IIdentityServerClient
    {
        Task<ServiceResult<Token>> GetApiToken(LoginByUserNameAndPassword options);
    }
}
