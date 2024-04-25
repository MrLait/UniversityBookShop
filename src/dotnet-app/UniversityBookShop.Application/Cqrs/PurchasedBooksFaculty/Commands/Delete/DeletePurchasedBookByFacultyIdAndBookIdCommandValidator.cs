using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Commands.Delete
{
    public class DeletePurchasedBookByFacultyIdAndBookIdCommandValidator: AbstractValidator<DeletePurchasedBookByFacultyIdAndBookIdCommand>
    {
        public DeletePurchasedBookByFacultyIdAndBookIdCommandValidator()
        {
            RuleFor(x => x.Facultyid)
                .GreaterThan(0).WithMessage(ApplicationConstants.Service.Error.GreaterThanZero);
            RuleFor(x => x.BookId)
                .GreaterThan(0).WithMessage(ApplicationConstants.Service.Error.GreaterThanZero);
        }
    }
}
