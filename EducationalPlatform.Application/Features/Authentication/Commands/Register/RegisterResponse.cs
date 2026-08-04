
namespace EducationalPlatform.Application.Features.Authentication.Commands.Register
{
    public class RegisterResponse
    {
        public bool Succeeded { get; set; }

        public string Message { get; set; } = string.Empty;

        public IEnumerable<string> Errors { get; set; } = [];
    }
}
