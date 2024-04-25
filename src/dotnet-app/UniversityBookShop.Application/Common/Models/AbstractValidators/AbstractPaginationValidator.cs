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
                .LessThanOrEqualTo(ApplicationConstants.Pagination.MaxPageSize).WithMessage(ApplicationConstants.Service.Error.PaginationMaxPageSize)
                .GreaterThan(0).WithMessage(ApplicationConstants.Service.Error.GreaterThanZero);
        }
    }
}
