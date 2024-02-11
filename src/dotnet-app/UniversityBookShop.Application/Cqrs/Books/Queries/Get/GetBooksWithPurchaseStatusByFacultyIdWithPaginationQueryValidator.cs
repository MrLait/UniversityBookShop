using FluentValidation;
using UniversityBookShop.Application.Common.Constants;
using UniversityBookShop.Application.Common.Models.AbstractValidators;

namespace UniversityBookShop.Application.Cqrs.Books.Queries.Get
{
    public class GetBooksWithPurchaseStatusByFacultyIdWithPaginationQueryValidator: AbstractPaginationValidator<GetBooksWithPurchaseStatusByFacultyIdWithPaginationQuery>
    {
        public GetBooksWithPurchaseStatusByFacultyIdWithPaginationQueryValidator()
        {
            RuleFor(x => x.FacultyId)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
