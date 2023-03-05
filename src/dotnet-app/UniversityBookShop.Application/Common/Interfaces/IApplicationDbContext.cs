using UniversityBookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace UniversityBookShop.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Faculty> Faculties { get; set; }
    DbSet<University> Universities { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
