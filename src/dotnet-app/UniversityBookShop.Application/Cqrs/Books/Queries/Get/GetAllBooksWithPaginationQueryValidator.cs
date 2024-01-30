using UniversityBookShop.Application.Common.Models.AbstractValidators;

namespace UniversityBookShop.Application.Cqrs.Books.Queries.Get
{
    public class GetAllBooksWithPaginationQueryValidator : AbstractPaginationValidator<GetAllBooksWithPaginationQuery>
    {
        public GetAllBooksWithPaginationQueryValidator()
        {
        }
    }
}
