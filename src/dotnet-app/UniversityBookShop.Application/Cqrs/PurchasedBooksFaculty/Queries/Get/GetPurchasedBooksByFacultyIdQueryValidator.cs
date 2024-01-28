using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Queries.Get
{
    public class GetPurchasedBooksByFacultyIdQueryValidator : AbstractValidator<GetPurchasedBooksByFacultyIdQuery>
    {
        public GetPurchasedBooksByFacultyIdQueryValidator()
        {
            RuleFor(x => x.FacultyId)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
