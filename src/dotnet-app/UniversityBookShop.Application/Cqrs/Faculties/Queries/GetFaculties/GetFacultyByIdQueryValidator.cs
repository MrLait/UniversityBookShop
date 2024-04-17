using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Cqrs.Faculties.Queries.GetFaculties
{
    public class GetFacultyByIdQueryValidator : AbstractValidator<GetFacultyByIdQuery>
    {
        public GetFacultyByIdQueryValidator()
        {
            RuleFor(x => x.FacultyId)
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ApplicationConstants.Service.Error.GreaterThanZero);
        }
    }
}
