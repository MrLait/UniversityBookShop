using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Common.Helpers
{
    public static class UniversityTotalBookPriceUpdater
    {
        public static async Task IncrementTotalBookPriceAsync(IApplicationDbContext dbContext, 
            int? universityId, decimal? curBookPrice,
            CancellationToken cancellationToken)
        {
            var university = await dbContext.Universities
                .Where(u => u.Id == universityId)
                .Include(x => x.CurrencyCode)
                .Include(x => x.Faculties)
                .FirstOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException(nameof(University), universityId ?? 0);

            university.TotalBookPrice = await dbContext.PurchasedBookFaculties
                .Where(x => x.Faculty.UniversityId == universityId)
                .SumAsync(x => x.Book!.Price, cancellationToken) + (curBookPrice ?? 0m);
        }

        public static async Task DecrementTotalBookPriceAsync(IApplicationDbContext dbContext,
            int? universityId, decimal? curBookPrice, 
            CancellationToken cancellationToken)
        {
            var university = await dbContext.Universities
                .Where(u => u.Id == universityId)
                .Include(x => x.CurrencyCode)
                .Include(x => x.Faculties)
                .FirstOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException(nameof(University), universityId ?? 0);

            university.TotalBookPrice = await dbContext.PurchasedBookFaculties
                .Where(x => x.Faculty.UniversityId == universityId)
                .SumAsync(x => x.Book!.Price, cancellationToken) - (curBookPrice ?? 0m);
        }
    }
}
