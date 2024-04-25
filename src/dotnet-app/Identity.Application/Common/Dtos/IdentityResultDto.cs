using Microsoft.AspNetCore.Identity;

namespace Identity.Application.Common.Dtos
{
    public class IdentityResultDto
    {
        public bool Succeeded { get; set; }

        public IEnumerable<IdentityError> Errors { get; set; }
    }
}