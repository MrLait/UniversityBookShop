using FluentValidation;
using UniversityBookShop.Application.Common.Constants;
using UniversityBookShop.Application.Common.Models.Pagination;

namespace UniversityBookShop.Application.Common.Models.AbstractValidators
{
    public class AbstractPaginationValidator<T> : AbstractValidator<T> where T : PaginationParams
    {
        public AbstractPaginationValidator()
        {
            RuleFor(x => x.PageSize)
                .LessThanOrEqualTo(PaginationConstants.MaxPageSize).WithMessage(ServiceErrorConstants.PaginationMaxPageSizeError)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
