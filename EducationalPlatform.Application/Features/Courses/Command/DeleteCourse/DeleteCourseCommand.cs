using EducationalPlatform.Application.Features.Courses.Commands.DeleteCourse;
using MediatR;

namespace EducationalPlatform.Application.Features.Courses.Commands.DeleteCourse;

public record DeleteCourseCommand(int Id) : IRequest<DeleteCourseResponse>;