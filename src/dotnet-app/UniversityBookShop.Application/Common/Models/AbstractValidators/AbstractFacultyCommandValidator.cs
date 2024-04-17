using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Common.Models.AbstractValidators
{
    public abstract class AbstractFacultyCommandValidator<T> : AbstractValidator<T> where T : FacultyCommandBase
    {
        public AbstractFacultyCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
                .MaximumLength(150).WithMessage(ApplicationConstants.Service.Error.MustBeLessThan);
            RuleFor(x => x.UniversityId)
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ApplicationConstants.Service.Error.GreaterThanZero);
        }
    }
}
