using EducationalPlatform.Application.DTOs;
using MediatR;

namespace EducationalPlatform.Application.Features.Courses.Queries.GetCourses;

public record GetCoursesQuery : IRequest<IReadOnlyList<CourseDto>>;