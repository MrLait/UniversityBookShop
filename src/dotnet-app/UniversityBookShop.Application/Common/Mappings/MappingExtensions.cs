using UniversityBookShop.Application.Common.Models;

namespace UniversityBookShop.Application.Common.Mappings;

public static class MappingExtensions
{
    public static async Task<PaginatedList<T>> PaginatedListAsync<T>(this IQueryable<T> source,
        int pageIndex, int pageSize, CancellationToken cancellationToken)
    {
        return await PaginatedList<T>.PaginatedListAsync(source, pageIndex, pageSize, cancellationToken);
    }

}
