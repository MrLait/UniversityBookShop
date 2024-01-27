using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Cqrs.Universities.Commands.Delete
{
    public class DeleteUniversityCommandValidation: AbstractValidator<DeleteUniversityCommand>
    {
        public DeleteUniversityCommandValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
