using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Cqrs.Universities.Commands.Delete
{
    public class DeleteUniversityCommandValidator: AbstractValidator<DeleteUniversityCommand>
    {
        public DeleteUniversityCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ApplicationConstants.Service.Error.GreaterThanZero);
        }
    }
}
