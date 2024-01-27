using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Common.Models.AbstractValidators
{
    public abstract class AbstractBookCommandValidator<T> : AbstractValidator<T> where T : BookCommandBase
    {
        public AbstractBookCommandValidator()
        {
            RuleFor(x => x.Isbn)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .MaximumLength(17).WithMessage(ServiceErrorConstants.MustBeLessThan);
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .MaximumLength(150).WithMessage(ServiceErrorConstants.MustBeLessThan);
            RuleFor(x => x.Author)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .MaximumLength(150).WithMessage(ServiceErrorConstants.MustBeLessThan);
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .PrecisionScale(10, 2, false).WithMessage(ServiceErrorConstants.PrecisionScale);
            RuleFor(x => x.CurrencyCodeId)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
