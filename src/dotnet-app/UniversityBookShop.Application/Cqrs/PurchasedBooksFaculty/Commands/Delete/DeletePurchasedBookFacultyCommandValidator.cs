using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Commands.Delete
{
    public class DeletePurchasedBookFacultyCommandValidator: AbstractValidator<DeletePurchasedBookFacultyCommand>
    {
        public DeletePurchasedBookFacultyCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
