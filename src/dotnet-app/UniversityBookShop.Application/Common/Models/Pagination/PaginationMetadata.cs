using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Common.Models.Pagination;

public class PaginationMetadata
{
    public int PageIndex { get; }
    public int TotalCount { get; }
    public int TotalPages { get; }
    public int PageSize { get; }
    public bool IsPrevious => PageIndex > PaginationConstants.FirstPage;
    public bool IsNext => PageIndex < TotalPages;

    public PaginationMetadata(int totalCount, int pageIndex, int pageSize)
    {
        TotalCount = totalCount;
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        PageSize = pageSize;
    }
}
