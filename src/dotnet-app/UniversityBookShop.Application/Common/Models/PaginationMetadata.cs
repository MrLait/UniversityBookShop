namespace UniversityBookShop.Application.Common.Models;

public class PaginationMetadata
{
    public int PageIndex { get; }
    public int TotalCount { get; }
    public int TotalPages { get; }
    public bool IsPrevious => PageIndex > 1;
    public bool IsNext => PageIndex < TotalPages;

    public PaginationMetadata(int totalCount, int pageIndex, int pageSize)
    {
        TotalCount = totalCount;
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
    }
}
