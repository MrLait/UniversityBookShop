using UniversityBookShop.Application.Common.Models;
using UniversityBookShop.Application.Common.Models.Api;

namespace UniversityBookShop.Application.Common.Interfaces
{
    public interface IIdentityServerClient
    {
        Task<Token> GetApiToken(LoginByUserNameAndPassword options);
    }
}
