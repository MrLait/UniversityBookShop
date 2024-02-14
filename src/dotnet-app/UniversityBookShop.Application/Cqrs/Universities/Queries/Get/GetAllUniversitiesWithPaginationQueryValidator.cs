using UniversityBookShop.Application.Common.Models.AbstractValidators;

namespace UniversityBookShop.Application.Cqrs.Universities.Queries.Get
{
    public class GetAllUniversitiesWithPaginationQueryValidator: AbstractPaginationValidator<GetAllUniversitiesWithPaginationQuery>
    {
        public GetAllUniversitiesWithPaginationQueryValidator()
        {
            
        }
    }
}
