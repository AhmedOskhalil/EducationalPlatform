using Microsoft.AspNetCore.Identity;

namespace EducationalPlatform.Infrastructure.Identity.Seed;

public static class AdminSeeder
{
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
    {
        const string email = "admin@educationalplatform.com";
        const string password = "Admin@123";

        var user = await userManager.FindByEmailAsync(email);

        if (user != null)
            return;

        user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            FirstName = "System",
            LastName = "Administrator",
            EmailConfirmed = true,
            IsActive = true
        };

        var result = await userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, Roles.Admin);
        }
    }
}