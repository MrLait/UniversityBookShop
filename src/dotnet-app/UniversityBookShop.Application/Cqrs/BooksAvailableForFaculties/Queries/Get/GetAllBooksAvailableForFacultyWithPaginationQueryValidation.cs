using FluentValidation;
using UniversityBookShop.Application.Common.Models.AbstractValidators;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Queries.Get
{
    public class GetAllBooksAvailableForFacultyWithPaginationQueryValidation : AbstractPaginationValidator<GetAllBooksAvailableForFacultyWithPaginationQuery>
    {
        public GetAllBooksAvailableForFacultyWithPaginationQueryValidation()
        {
        }
    }
}
