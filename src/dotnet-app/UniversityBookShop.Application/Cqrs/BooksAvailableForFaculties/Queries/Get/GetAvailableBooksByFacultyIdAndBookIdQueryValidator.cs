using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Queries.Get
{
    public class GetAvailableBooksByFacultyIdAndBookIdQueryValidator :
        AbstractValidator<GetAvailableBooksByFacultyIdAndBookIdQuery>
    {
        public GetAvailableBooksByFacultyIdAndBookIdQueryValidator()
        {
            RuleFor(x => x.FacultyId)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
            RuleFor(x => x.BookId)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
