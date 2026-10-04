using EducationalPlatform.Application.Interfaces;
using MediatR;

namespace EducationalPlatform.Application.Features.Courses.Commands.UpdateCourse;

public class UpdateCourseCommandHandler
    : IRequestHandler<UpdateCourseCommand, UpdateCourseResponse>
{
    private readonly ICourseService _courseService;

    public UpdateCourseCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<UpdateCourseResponse> Handle(
        UpdateCourseCommand request,
        CancellationToken cancellationToken)
    {
        return await _courseService.UpdateCourseAsync(request);
    }
}