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
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ApplicationConstants.Service.Error.GreaterThanZero);
        }
    }
}
