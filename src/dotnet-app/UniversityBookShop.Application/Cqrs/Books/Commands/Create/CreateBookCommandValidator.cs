using UniversityBookShop.Application.Common.Models.AbstractValidators;

namespace UniversityBookShop.Application.Cqrs.Books.Commands.Create
{
    public class CreateBookCommandValidator : AbstractBookCommandValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            
        }
    }
}
