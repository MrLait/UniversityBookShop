using FluentValidation;
using UniversityBookShop.Application.Common.Constants;
using UniversityBookShop.Application.Cqrs.Books.Commands.AbstractValidator;

namespace UniversityBookShop.Application.Cqrs.Books.Commands.Update
{
    public class UpdateBookCommandValidator : AbstractBookCommandValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.Id)
                 .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
