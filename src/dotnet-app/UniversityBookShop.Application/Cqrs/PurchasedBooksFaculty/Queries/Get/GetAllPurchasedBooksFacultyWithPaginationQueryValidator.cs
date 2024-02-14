using UniversityBookShop.Application.Common.Models.AbstractValidators;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Queries.Get
{
    public class GetAllPurchasedBooksFacultyWithPaginationQueryValidator : AbstractPaginationValidator<GetAllPurchasedBooksFacultyWithPaginationQuery>
    {
        public GetAllPurchasedBooksFacultyWithPaginationQueryValidator()
        {
        }
    }
}
