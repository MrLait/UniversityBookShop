using FluentValidation;
using UniversityBookShop.Application.Common.Constants;
using UniversityBookShop.Application.Common.Models.AbstractValidators;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Queries.Get
{
    public class GetAvailableBooksByFacultyIdAndBookIdWithPaginationQueryValidator :
        AbstractPaginationValidator<GetAvailableBooksByFacultyIdAndBookIdWithPaginationQuery>
    {
        public GetAvailableBooksByFacultyIdAndBookIdWithPaginationQueryValidator()
        {
            RuleFor(x => x.FacultyId)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
            RuleFor(x => x.BookId)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
