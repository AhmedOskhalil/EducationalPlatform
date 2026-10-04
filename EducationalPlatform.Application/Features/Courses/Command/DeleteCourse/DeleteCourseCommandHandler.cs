using EducationalPlatform.Application.Interfaces;
using MediatR;

namespace EducationalPlatform.Application.Features.Courses.Commands.DeleteCourse;

public class DeleteCourseCommandHandler
    : IRequestHandler<DeleteCourseCommand, DeleteCourseResponse>
{
    private readonly ICourseService _courseService;

    public DeleteCourseCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<DeleteCourseResponse> Handle(
        DeleteCourseCommand request,
        CancellationToken cancellationToken)
    {
        return await _courseService.DeleteCourseAsync(request);
    }
}