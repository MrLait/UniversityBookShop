using FluentValidation;
using UniversityBookShop.Application.Common.Constants;
using UniversityBookShop.Application.Common.Models.AbstractValidators;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Queries.Get
{
    public class GetPurchasedBooksByUniversityIdWithPaginationQueryValidator: AbstractPaginationValidator<GetPurchasedBooksByUniversityIdWithPaginationQuery>
    {
        public GetPurchasedBooksByUniversityIdWithPaginationQueryValidator()
        {
            RuleFor(x => x.UniversityId)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
