using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Cqrs.Books.Commands.Delete;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
            .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
    }
}
