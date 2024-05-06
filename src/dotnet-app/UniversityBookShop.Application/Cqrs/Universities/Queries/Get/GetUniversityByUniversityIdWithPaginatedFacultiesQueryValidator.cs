using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Cqrs.Universities.Queries.Get
{
    public class GetUniversityByUniversityIdWithPaginatedFacultiesQueryValidator : AbstractValidator<GetUniversityByUniversityIdWithPaginatedFacultiesQuery>
    {
        public GetUniversityByUniversityIdWithPaginatedFacultiesQueryValidator()
        {
            RuleFor(x => x.UniversityId)
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ApplicationConstants.Service.Error.GreaterThanZero);
        }
    }
}
