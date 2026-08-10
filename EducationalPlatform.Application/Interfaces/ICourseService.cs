using EducationalPlatform.Application.Features.Courses.Commands.CreateCourse;
using EducationalPlatform.Application.Features.Courses.Commands.DeleteCourse;
using EducationalPlatform.Application.Features.Courses.Commands.UpdateCourse;
using EducationalPlatform.Domain.Entities;

namespace EducationalPlatform.Application.Interfaces;

public interface ICourseService
{
    Task<CreateCourseResponse> CreateCourseAsync(CreateCourseCommand command);
    Task<IReadOnlyList<Course>> GetAllAsync();
    Task<UpdateCourseResponse> UpdateCourseAsync(UpdateCourseCommand command);
    Task<DeleteCourseResponse> DeleteCourseAsync(DeleteCourseCommand command);
}