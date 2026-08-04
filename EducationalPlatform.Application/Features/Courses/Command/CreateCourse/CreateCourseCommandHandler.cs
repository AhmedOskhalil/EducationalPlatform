using EducationalPlatform.Application.Interfaces;
using MediatR;

namespace EducationalPlatform.Application.Features.Courses.Commands.CreateCourse;

public class CreateCourseCommandHandler
    : IRequestHandler<CreateCourseCommand, CreateCourseResponse>
{
    private readonly ICourseService _courseService;

    public CreateCourseCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<CreateCourseResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        return await _courseService.CreateCourseAsync(request);
    }
}