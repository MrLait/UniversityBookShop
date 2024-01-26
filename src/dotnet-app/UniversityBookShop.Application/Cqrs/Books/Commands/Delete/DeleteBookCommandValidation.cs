using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Cqrs.Books.Commands.Delete;

public class DeleteBookCommandValidation : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
            .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
    }
}
