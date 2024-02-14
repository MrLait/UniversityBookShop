using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Common.Models.Pagination;

public class PaginationParams
{
    private const int _defaultPageSize = PaginationConstants.MaxPageSize;

    public int PageIndex { get; set; } = PaginationConstants.FirstPage;
    public int PageSize { get; set; } = _defaultPageSize;

    protected void SetPaginationParams(PaginationParams paginationParams)
    {
        PageIndex = paginationParams.PageIndex;
        PageSize = paginationParams.PageSize;
    }
}
