using FluentValidation;
using UniversityBookShop.Application.Common.Constants;
using UniversityBookShop.Application.Common.Models.AbstractValidators;

namespace UniversityBookShop.Application.Cqrs.Faculties.Queries.GetFaculties
{
    public class GetFacultiesByUniversityIdQueryValidator : AbstractPaginationValidator<GetFacultiesByUniversityIdQuery>
    {
        public GetFacultiesByUniversityIdQueryValidator()
        {
            RuleFor(x => x.UniversityId)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
