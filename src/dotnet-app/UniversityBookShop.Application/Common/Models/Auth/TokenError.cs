using Newtonsoft.Json;

namespace UniversityBookShop.Application.Common.Models.Auth
{
    public class TokenError
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
