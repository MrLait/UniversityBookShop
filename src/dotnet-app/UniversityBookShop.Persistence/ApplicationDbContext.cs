using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Domain.Entities;
using UniversityBookShop.Persistence.EntityTypeConfigurations;

namespace UniversityBookShop.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Faculty> Faculties { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new FacultiesConfiguration());
        base.OnModelCreating(builder);
    }
}
