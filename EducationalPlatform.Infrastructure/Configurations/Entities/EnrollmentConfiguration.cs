using EducationalPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalPlatform.Infrastructure.Configurations.Entities;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.ToTable("Enrollments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProgressPercentage)
               .HasPrecision(5, 2);

        builder.Property(x => x.IsCompleted)
               .HasDefaultValue(false);

        builder.Property(x => x.IsActive)
               .HasDefaultValue(true);

        builder.HasOne(x => x.Course)
               .WithMany(x => x.Enrollments)
               .HasForeignKey(x => x.CourseId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}