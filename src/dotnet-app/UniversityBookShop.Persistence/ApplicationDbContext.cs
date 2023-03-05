using System.Reflection;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Faculty> Faculties { get; set; } = null!;
    public DbSet<University> Universities { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
