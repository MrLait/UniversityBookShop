
using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Commands.Create
{
    public class CreatePurchasedBooksFacultyCommandValidator : AbstractValidator<CreatePurchasedBooksFacultyCommand>
    {
        public CreatePurchasedBooksFacultyCommandValidator()
        {
            RuleFor(x => x.BookId)
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ApplicationConstants.Service.Error.GreaterThanZero);
            RuleFor(x => x.FacultyId)
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ApplicationConstants.Service.Error.GreaterThanZero);
        }
    }
}
