using Identity.Domain.Models;

namespace Identity.Application.Common.Models.Requests
{
    public class CreateUserRequest
    {
        public ApplicationUser User { get; set; }

        public string Password { get; set; }
    }
}