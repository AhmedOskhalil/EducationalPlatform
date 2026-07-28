using EducationalPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalPlatform.Infrastructure.Configurations.Entities;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("Lessons");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(x => x.Description)
               .HasMaxLength(3000);

        builder.Property(x => x.DisplayOrder)
               .IsRequired();

        builder.Property(x => x.IsPreview)
               .HasDefaultValue(false);

        builder.HasOne(x => x.Section)
               .WithMany(x => x.Lessons)
               .HasForeignKey(x => x.SectionId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}