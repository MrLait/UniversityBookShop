using UniversityBookShop.Application.Common.Models.AbstractValidators;

namespace UniversityBookShop.Application.Cqrs.Faculties.Commands.Create
{
    public class CreateFacultyCommandValidation: AbstractFacultyCommandValidator<CreateFacultyCommand>
    {
        public CreateFacultyCommandValidation()
        {
        }
    }
}
