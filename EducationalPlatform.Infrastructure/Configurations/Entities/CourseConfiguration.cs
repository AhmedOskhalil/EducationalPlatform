using EducationalPlatform.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalPlatform.Domain.Entities;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(x => x.Slug)
               .IsRequired()
               .HasMaxLength(200);

        builder.HasIndex(x => x.Slug)
               .IsUnique();

        builder.Property(x => x.ShortDescription)
               .HasMaxLength(500);

        builder.Property(x => x.Description)
               .HasMaxLength(5000);

        builder.Property(x => x.ThumbnailUrl)
               .HasMaxLength(500);

        builder.Property(x => x.Price)
               .HasPrecision(18, 2);

        builder.HasOne(x => x.Category)
               .WithMany(x => x.Courses)
               .HasForeignKey(x => x.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Status)
       .HasDefaultValue(CourseStatus.Draft);
    }
}