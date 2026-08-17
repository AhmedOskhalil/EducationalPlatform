using EducationalPlatform.Application.DTOs;
using EducationalPlatform.Application.Interfaces;
using EducationalPlatform.Domain.Entities;
using MediatR;

namespace EducationalPlatform.Application.Features.Courses.Queries.GetCourseById;

public class GetCourseByIdQueryHandler
    : IRequestHandler<GetCourseByIdQuery, CourseDetailsDto?>
{
    private readonly IRepository<Course> _courseRepository;

    public GetCourseByIdQueryHandler(
        IRepository<Course> courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<CourseDetailsDto?> Handle(
        GetCourseByIdQuery request,
        CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetByIdAsync(request.Id);

        if (course is null)
            return null;

        return new CourseDetailsDto
        {
            Id = course.Id,
            Title = course.Title,
            Slug = course.Slug,
            ShortDescription = course.ShortDescription,
            Description = course.Description,
            Price = course.Price,
            Difficulty = course.Difficulty,
            DeliveryType = course.DeliveryType,
            Status = course.Status,
            CategoryId = course.CategoryId
        };
    }
}