using FluentValidation;
using UniversityBookShop.Application.Common.Constants;
using UniversityBookShop.Application.Common.Models.AbstractValidators;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Queries.Get
{
    public class GetPurchasedBooksByFacultyIdWithPaginationQueryValidator : AbstractPaginationValidator<GetPurchasedBooksByFacultyIdWithPaginationQuery>
    {
        public GetPurchasedBooksByFacultyIdWithPaginationQueryValidator()
        {
            RuleFor(x => x.FacultyId)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
