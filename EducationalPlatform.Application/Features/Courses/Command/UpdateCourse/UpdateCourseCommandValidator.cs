using EducationalPlatform.Application.DTOs;
using EducationalPlatform.Application.Interfaces;
using EducationalPlatform.Domain.Entities;
using FluentValidation;

namespace EducationalPlatform.Application.Features.Courses.Commands.UpdateCourse;

public class UpdateCourseCommandValidator
    : AbstractValidator<UpdateCourseCommand>
{
    public UpdateCourseCommandValidator(IRepository<Course> courseRepository)
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Slug)
            .NotEmpty()
            .MaximumLength(200)
            .MustAsync(async (command, slug, cancellationToken) =>
            {
                var existingCourses = await courseRepository.FindAsync(
                    x => x.Slug == slug);

                return !existingCourses.Any(x => x.Id != command.Id);
            })
            .WithMessage("A course with this slug already exists.");

        RuleFor(x => x.ShortDescription)
            .MaximumLength(500);

        RuleFor(x => x.Description)
            .NotEmpty();

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.CategoryId)
            .NotEmpty();
    }
}