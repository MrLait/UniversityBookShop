using Microsoft.EntityFrameworkCore;

namespace UniversityBookShop.Application.Common.Models.Pagination;

public class PaginatedList<T> : PaginationMetadata
{
    public List<T> Items { get; }

    public PaginatedList(List<T> items, int totalCount, int pageIndex, int pageSize)
        : base(totalCount, pageIndex, pageSize)
    {
        Items = items;
    }

    public static async Task<PaginatedList<T>> PaginatedListAsync(IQueryable<T> source, int pageIndex, int pageSize, CancellationToken cancellationToken)
    {
        var totalCount = await source.CountAsync(cancellationToken);
        var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        return new PaginatedList<T>(items, totalCount, pageIndex, pageSize);
    }
}
