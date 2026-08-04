using EducationalPlatform.Application.Features.Courses.Commands.CreateCourse;

namespace EducationalPlatform.Application.Interfaces;

public interface ICourseService
{
    Task<CreateCourseResponse> CreateCourseAsync(CreateCourseCommand command);
}