using EducationalPlatform.Application.DTOs;
using EducationalPlatform.Application.Interfaces;
using EducationalPlatform.Domain.Entities;
using MediatR;

namespace EducationalPlatform.Application.Features.Courses.Queries.GetCourseById;

public class GetCourseByIdQueryHandler
    : IRequestHandler<GetCourseByIdQuery, Course?>
{
    private readonly IRepository<Course> _courseRepository;

    public GetCourseByIdQueryHandler(
        IRepository<Course> courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<Course?> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        return await _courseRepository.GetByIdAsync(request.Id);
    }
}