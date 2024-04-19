using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Common.Models.AbstractValidators
{
    public abstract class AbstractUniversityCommandValidator<T> : AbstractValidator<T> where T : UniversityCommandBase
    {
        public AbstractUniversityCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
                .MaximumLength(150).WithMessage(ApplicationConstants.Service.Error.MustBeLessThan);
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
                .MaximumLength(255).WithMessage(ApplicationConstants.Service.Error.MustBeLessThan);
            RuleFor(x => x.CurrencyCodeId)
                .GreaterThan(0).WithMessage(ApplicationConstants.Service.Error.GreaterThanZero);
        }
    }
}
