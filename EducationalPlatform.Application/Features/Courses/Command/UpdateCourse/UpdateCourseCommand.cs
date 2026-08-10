using EducationalPlatform.Domain.Enums;
using MediatR;

namespace EducationalPlatform.Application.Features.Courses.Commands.UpdateCourse;

public record UpdateCourseCommand(
    int Id,
    string Title,
    string Slug,
    string ShortDescription,
    string Description,
    decimal Price,
    int CategoryId,
    CourseDifficulty Difficulty,
    CourseDeliveryType DeliveryType
) : IRequest<UpdateCourseResponse>;