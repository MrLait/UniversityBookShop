using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Commands.Create
{
    public class AddBooksAvailableForFacultyCommandValidator: AbstractValidator<AddBooksAvailableForFacultyCommand>
    {
        public AddBooksAvailableForFacultyCommandValidator()
        {
            RuleFor(x => x.FacultyId)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
            //RuleFor(x => x.UniversityId)
            //    .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
            //    .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
            RuleFor(x => x.BookId)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
