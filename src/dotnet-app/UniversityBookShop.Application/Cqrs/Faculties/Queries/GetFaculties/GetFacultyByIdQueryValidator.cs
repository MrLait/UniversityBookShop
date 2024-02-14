using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Cqrs.Faculties.Queries.GetFaculties
{
    public class GetFacultyByIdQueryValidator : AbstractValidator<GetFacultyByIdQuery>
    {
        public GetFacultyByIdQueryValidator()
        {
            RuleFor(x => x.FacultyId)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
