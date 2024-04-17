using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Common.Models.AbstractValidators
{
    public abstract class AbstractBookCommandValidator<T> : AbstractValidator<T> where T : BookCommandBase
    {
        public AbstractBookCommandValidator()
        {
            RuleFor(x => x.Isbn)
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
                .MaximumLength(17).WithMessage(ApplicationConstants.Service.Error.MustBeLessThan);
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
                .MaximumLength(150).WithMessage(ApplicationConstants.Service.Error.MustBeLessThan);
            RuleFor(x => x.Author)
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
                .MaximumLength(150).WithMessage(ApplicationConstants.Service.Error.MustBeLessThan);
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty)
                .PrecisionScale(10, 2, false).WithMessage(ApplicationConstants.Service.Error.PrecisionScale);
            RuleFor(x => x.CurrencyCodeId)
                .GreaterThan(0).WithMessage(ApplicationConstants.Service.Error.GreaterThanZero);
        }
    }
}
