using EducationalPlatform.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EducationalPlatform.Domain.Entities;

namespace EducationalPlatform.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Section> Sections => Set<Section>();
    public DbSet<Lesson> Lessons => Set<Lesson>();
    public DbSet<LessonContent> LessonContents => Set<LessonContent>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        // Entity configurations will be added here later.
    }
}