using FluentValidation;
using UniversityBookShop.Application.Common.Constants;
using UniversityBookShop.Application.Common.Models.AbstractValidators;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Queries.Get
{
    public class GetAvailableBooksByFacultyIdWithPaginationQueryValidator:
        AbstractPaginationValidator<GetAvailableBooksByFacultyIdWithPaginationQuery>
    {
        public GetAvailableBooksByFacultyIdWithPaginationQueryValidator()
        {
            RuleFor(x => x.FacultyId)
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ApplicationConstants.Service.Error.GreaterThanZero);
        }
    }
}
