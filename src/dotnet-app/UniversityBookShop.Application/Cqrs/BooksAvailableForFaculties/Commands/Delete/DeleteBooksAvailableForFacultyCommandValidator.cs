using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Commands.Delete
{
    public class DeleteBooksAvailableForFacultyCommandValidator: AbstractValidator<DeleteBooksAvailableForFacultyCommand>
    {
        public DeleteBooksAvailableForFacultyCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ApplicationConstants.Service.Error.GreaterThanZero);
        }
    }
}
