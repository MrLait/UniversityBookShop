namespace UniversityBookShop.Application.Common.Models;

public class PaginationParams
{
    private const int _maxPageSize = 50;
    private int _pageSize = 50;
    public int PageIndex { get; set; } = 1;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > _maxPageSize ? _maxPageSize : value;
    }

}
