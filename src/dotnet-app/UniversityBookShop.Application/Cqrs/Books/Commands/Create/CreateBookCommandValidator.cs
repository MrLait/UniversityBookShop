using FluentValidation;
namespace UniversityBookShop.Application.Cqrs.Books.Commands.Create
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.CurrencyCodeId).GreaterThan(0).WithMessage("CurrencyCodeId should be more than zero");
        }
    }
}
