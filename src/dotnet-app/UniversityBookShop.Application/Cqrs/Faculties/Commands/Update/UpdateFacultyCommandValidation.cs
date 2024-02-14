using FluentValidation;
using UniversityBookShop.Application.Common.Constants;
using UniversityBookShop.Application.Common.Models.AbstractValidators;

namespace UniversityBookShop.Application.Cqrs.Faculties.Commands.Update
{
    public class UpdateFacultyCommandValidation : AbstractFacultyCommandValidator<UpdateFacultyCommand>
    {
        public UpdateFacultyCommandValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
