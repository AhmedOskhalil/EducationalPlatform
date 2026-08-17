using EducationalPlatform.Application.Common.Behaviors;
using EducationalPlatform.Application.Features.Courses.Commands.CreateCourse;
using EducationalPlatform.Application.Interfaces;
using EducationalPlatform.Infrastructure.Data;
using EducationalPlatform.Infrastructure.Identity;
using EducationalPlatform.Infrastructure.Identity.Seed;
using EducationalPlatform.Infrastructure.Persistence;
using EducationalPlatform.Infrastructure.Repositories;
using EducationalPlatform.Infrastructure.Services;
using EducationalPlatform.Web.Components;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EducationalPlatform.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents().AddInteractiveServerComponents();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddIdentityCookies();

            builder.Services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            builder.Services.AddAuthorization();

            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/login";
                options.LogoutPath = "/logout";
                options.AccessDeniedPath = "/access-denied";

                options.SlidingExpiration = true;

                options.ExpireTimeSpan = TimeSpan.FromDays(30);
            });

            builder.Services.AddValidatorsFromAssembly(typeof(CreateCourseCommandValidator).Assembly);

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(
                    typeof(EducationalPlatform.Application.Interfaces.IRepository<>).Assembly);

                cfg.AddOpenBehavior(
                    typeof(ValidationBehavior<,>));
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var dbContext = services.GetRequiredService<ApplicationDbContext>();

                await RoleSeeder.SeedAsync(roleManager);
                await AdminSeeder.SeedAsync(userManager);
                await CategorySeeder.SeedAsync(dbContext);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();
            

            await app.RunAsync();
        }
    }
}
