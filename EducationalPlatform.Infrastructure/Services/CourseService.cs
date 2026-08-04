using EducationalPlatform.Application.Features.Courses.Commands.CreateCourse;
using EducationalPlatform.Application.Interfaces;

namespace EducationalPlatform.Infrastructure.Services;

public class CourseService : ICourseService
{
    public Task<CreateCourseResponse> CreateCourseAsync(CreateCourseCommand command)
    {
        throw new NotImplementedException();
    }
}