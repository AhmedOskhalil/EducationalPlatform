using MediatR;

namespace EducationalPlatform.Application.Features.Authentication.Commands.Login;

public record LoginCommand(
    string Email,
    string Password,
    bool RememberMe
) : IRequest<LoginResponse>;