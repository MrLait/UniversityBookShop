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
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ApplicationConstants.Service.Error.GreaterThanZero);
        }
    }
}
