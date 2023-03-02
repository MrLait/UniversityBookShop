using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Persistence.EntityTypeConfigurations;

public class FacultiesConfiguration : IEntityTypeConfiguration<Faculties>
{
    public void Configure(EntityTypeBuilder<Faculties> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Name).HasColumnName("name").HasMaxLength(150);
    }
}
