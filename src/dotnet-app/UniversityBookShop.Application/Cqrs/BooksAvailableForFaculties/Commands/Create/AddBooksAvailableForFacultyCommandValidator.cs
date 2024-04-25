using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Commands.Create
{
    public class AddBooksAvailableForFacultyCommandValidator: AbstractValidator<AddBooksAvailableForFacultyCommand>
    {
        public AddBooksAvailableForFacultyCommandValidator()
        {
            RuleFor(x => x.FacultyId)
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ApplicationConstants.Service.Error.GreaterThanZero);
            //RuleFor(x => x.UniversityId)
            //    .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
            //    .GreaterThan(0).WithMessage(ApplicationConstants.Service.Error.GreaterThanZero);
            RuleFor(x => x.BookId)
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ApplicationConstants.Service.Error.GreaterThanZero);
        }
    }
}
