using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Persistence.EntityTypeConfigurations;

public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
{
    public void Configure(EntityTypeBuilder<Faculty> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Name).HasColumnName("name").HasMaxLength(150);

        builder
            .HasOne(u => u.University)
            .WithMany(f => f.Faculties)
            .HasForeignKey(fk => fk.UniversityId);
    }
}