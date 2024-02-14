
using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Commands.Create
{
    public class CreatePurchasedBooksFacultyCommandValidator : AbstractValidator<CreatePurchasedBooksFacultyCommand>
    {
        public CreatePurchasedBooksFacultyCommandValidator()
        {
            RuleFor(x => x.BookId)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
            RuleFor(x => x.FacultyId)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
