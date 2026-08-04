namespace EducationalPlatform.Application.Features.Authentication.Commands.Login;

public class LoginResponse
{
    public bool Succeeded { get; set; }

    public string Message { get; set; } = string.Empty;
}