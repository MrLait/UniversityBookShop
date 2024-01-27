using FluentValidation;
using UniversityBookShop.Application.Common.Constants;
using UniversityBookShop.Application.Cqrs.Faculties.Commands.Update;

namespace UniversityBookShop.Application.Cqrs.Faculties.Commands.Delete
{
    public class DeleteFacultyCommandValidation: AbstractValidator<DeleteFacultyCommand>
    {
        public DeleteFacultyCommandValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
