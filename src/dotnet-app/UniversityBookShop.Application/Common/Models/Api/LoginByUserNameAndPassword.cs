using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Common.Models.Api
{
    public class LoginByUserNameAndPassword
    {
        public string ClientId { get; set; } = ApiConstants.Identity.ClientId;
        public string Scope { get; set; } = ApiConstants.Identity.WebScope;
        public string GrantType { get; set; } = ApiConstants.Identity.GrantType.ResourceOwnerPassword;
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
