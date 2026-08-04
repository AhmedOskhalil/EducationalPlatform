using EducationalPlatform.Application.Features.Authentication.Commands.Register;

namespace EducationalPlatform.Application.Interfaces;

public interface IAuthenticationService
{
    Task<RegisterResponse> RegisterAsync(RegisterCommand command);
}