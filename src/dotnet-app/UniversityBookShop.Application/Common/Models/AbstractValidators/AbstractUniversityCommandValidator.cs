using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Common.Models.AbstractValidators
{
    public abstract class AbstractUniversityCommandValidator<T> : AbstractValidator<T> where T : UniversityCommandBase
    {
        public AbstractUniversityCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .MaximumLength(150).WithMessage(ServiceErrorConstants.MustBeLessThan);
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .MaximumLength(255).WithMessage(ServiceErrorConstants.MustBeLessThan);
            RuleFor(x => x.CurrencyCodeId)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
