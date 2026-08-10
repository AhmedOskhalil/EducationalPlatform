using EducationalPlatform.Domain.Enums;
using MediatR;

namespace EducationalPlatform.Application.Features.Courses.Commands.CreateCourse;

public record CreateCourseCommand(
    string Title,
    string Slug,
    string ShortDescription,
    string Description,
    decimal Price,
    int CategoryId,
    CourseDifficulty Difficulty,
    CourseDeliveryType DeliveryType
) : IRequest<CreateCourseResponse>;