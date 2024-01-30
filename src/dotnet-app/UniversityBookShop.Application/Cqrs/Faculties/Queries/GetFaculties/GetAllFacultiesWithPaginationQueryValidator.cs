using UniversityBookShop.Application.Common.Models.AbstractValidators;

namespace UniversityBookShop.Application.Cqrs.Faculties.Queries.GetFaculties
{
    public class GetAllFacultiesWithPaginationQueryValidator : AbstractPaginationValidator<GetAllFacultiesWithPaginationQuery>
    {
        public GetAllFacultiesWithPaginationQueryValidator()
        {
        }
    }
}
