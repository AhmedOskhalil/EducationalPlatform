
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EducationalPlatform.Infrastructure.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=DESKTOP-4732S74;Database=EducationalPlatformDb;User Id=sa;Password=123aaa;TrustServerCertificate=True;MultipleActiveResultSets=True;");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}