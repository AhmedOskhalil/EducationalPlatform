using EducationalPlatform.Application.DTOs;
using EducationalPlatform.Application.Interfaces;
using MediatR;

namespace EducationalPlatform.Application.Features.Courses.Queries.GetCourses;

public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, IReadOnlyList<CourseDto>>
{
    private readonly ICourseService _courseService;

    public GetCoursesQueryHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<IReadOnlyList<CourseDto>> Handle(
        GetCoursesQuery request,
        CancellationToken cancellationToken)
    {
        var courses = await _courseService.GetAllAsync();

        return courses.Select(course => new CourseDto
        {
            Id = course.Id,
            Title = course.Title,
            Slug = course.Slug,
            ShortDescription = course.ShortDescription,
            Price = course.Price,
            Difficulty = course.Difficulty,
            DeliveryType = course.DeliveryType,
            Status = course.Status,
            CategoryId = course.CategoryId
        }).ToList();
    }
}