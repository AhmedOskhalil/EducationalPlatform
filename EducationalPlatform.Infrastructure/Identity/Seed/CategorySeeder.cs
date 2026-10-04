using EducationalPlatform.Domain.Entities;
using EducationalPlatform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform.Infrastructure.Identity.Seed;

public static class CategorySeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.Categories.AnyAsync())
            return;

        var categories = new List<Category>
        {
            new Category
            {
                Name = "Programming"
            },
            new Category
            {
                Name = "Web Development"
            },
            new Category
            {
                Name = "Database"
            },
            new Category
            {
                Name = "Software Engineering"
            },
            new Category
            {
                Name = "DevOps"
            }
        };

        await context.Categories.AddRangeAsync(categories);
        await context.SaveChangesAsync();
    }
}