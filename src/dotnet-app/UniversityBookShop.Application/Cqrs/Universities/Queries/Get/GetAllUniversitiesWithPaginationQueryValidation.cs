using UniversityBookShop.Application.Common.Models.AbstractValidators;

namespace UniversityBookShop.Application.Cqrs.Universities.Queries.Get
{
    public class GetAllUniversitiesWithPaginationQueryValidation: AbstractPaginationValidator<GetAllUniversitiesWithPaginationQuery>
    {
        public GetAllUniversitiesWithPaginationQueryValidation()
        {
            
        }
    }
}
