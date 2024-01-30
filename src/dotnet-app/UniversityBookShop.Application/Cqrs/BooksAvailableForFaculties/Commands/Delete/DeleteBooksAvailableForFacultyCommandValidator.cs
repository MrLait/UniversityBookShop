using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Commands.Delete
{
    public class DeleteBooksAvailableForFacultyCommandValidator: AbstractValidator<DeleteBooksAvailableForFacultyCommand>
    {
        public DeleteBooksAvailableForFacultyCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
