using EducationalPlatform.Application.DTOs;
using EducationalPlatform.Domain.Entities;
using MediatR;

namespace EducationalPlatform.Application.Features.Courses.Queries.GetCourseById;

public record GetCourseByIdQuery(int Id) : IRequest<CourseDetailsDto?>;