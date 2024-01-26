using UniversityBookShop.Application.Cqrs.Books.Commands.AbstractValidator;
namespace UniversityBookShop.Application.Cqrs.Books.Commands.Create
{
    public class CreateBookCommandValidator : AbstractBookCommandValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            
        }
    }
}
