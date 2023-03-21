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
        builder.Property(f => f.UniversityId).HasColumnName("university_id");

        builder
            .HasOne(pb => pb.PurchasedBookFaculty)
            .WithOne(f => f.Faculty)
            .HasForeignKey<PurchasedBookFaculty>(fk => fk.FacultyPurchasedBookFacultyId);

        builder
            .HasOne(ba => ba.BooksAvailableForFaculty)
            .WithOne(f => f.Faculty)
            .HasForeignKey<BooksAvailableForFaculty>(fk => fk.FacultyId);

        builder
            .HasOne<University>(u => u.University)
            .WithMany(f => f.Faculties)
            .HasForeignKey(fk => fk.UniversityId);
    }
}
