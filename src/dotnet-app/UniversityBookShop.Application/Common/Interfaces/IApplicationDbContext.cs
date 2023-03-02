using UniversityBookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace UniversityBookShop.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Faculties> Faculties { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
