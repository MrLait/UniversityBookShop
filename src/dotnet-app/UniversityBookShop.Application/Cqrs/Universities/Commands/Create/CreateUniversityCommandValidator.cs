using UniversityBookShop.Application.Common.Models.AbstractValidators;

namespace UniversityBookShop.Application.Cqrs.Universities.Commands.Create
{
    public class CreateUniversityCommandValidator : AbstractUniversityCommandValidator<CreateUniversityCommand>
    {
        public CreateUniversityCommandValidator()
        {
        }
    }
}
