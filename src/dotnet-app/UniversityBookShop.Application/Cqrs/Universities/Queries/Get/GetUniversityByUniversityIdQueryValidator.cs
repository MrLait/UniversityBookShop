using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Cqrs.Universities.Queries.Get
{
    public class GetUniversityByUniversityIdQueryValidator: AbstractValidator<GetUniversityByUniversityIdQuery>
    {
        public GetUniversityByUniversityIdQueryValidator()
        {
            RuleFor(x => x.UniversityId)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
