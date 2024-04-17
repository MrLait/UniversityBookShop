using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Commands.Delete
{
    public class DeletePurchasedBookFacultyCommandValidator : AbstractValidator<DeletePurchasedBookFacultyCommand>
    {
        public DeletePurchasedBookFacultyCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ApplicationConstants.Service.Error.GreaterThanZero);
        }
    }
}
