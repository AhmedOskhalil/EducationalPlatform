using EducationalPlatform.Application.Features.Authentication.Commands.Register;
using EducationalPlatform.Application.Interfaces;
using EducationalPlatform.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace EducationalPlatform.Infrastructure.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthenticationService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterCommand command)
    {
        var existingUser = await _userManager.FindByEmailAsync(command.Email);

        if (existingUser != null)
        {
            return new RegisterResponse
            {
                Succeeded = false,
                Message = "Email already exists."
            };
        }

        var user = new ApplicationUser
        {
            UserName = command.Email,
            Email = command.Email,
            FirstName = command.FirstName,
            LastName = command.LastName,
            EmailConfirmed = true,
            IsActive = true
        };

        var result = await _userManager.CreateAsync(user, command.Password);

        if (!result.Succeeded)
        {
            return new RegisterResponse
            {
                Succeeded = false,
                Message = "Registration failed.",
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        await _userManager.AddToRoleAsync(user, Roles.Student);

        return new RegisterResponse
        {
            Succeeded = true,
            Message = "Registration completed successfully."
        };
    }
}