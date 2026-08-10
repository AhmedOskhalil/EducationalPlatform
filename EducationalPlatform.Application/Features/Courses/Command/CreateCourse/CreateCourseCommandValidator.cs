using EducationalPlatform.Application.Interfaces;
using FluentValidation;

namespace EducationalPlatform.Application.Features.Courses.Commands.CreateCourse;

public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator(IRepository<Domain.Entities.Course> courseRepository)
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Slug)
            .NotEmpty()
            .MaximumLength(200).MustAsync(async (slug, cancellationToken) =>
                !await courseRepository.ExistsAsync(
                    x => x.Slug == slug))
            .WithMessage("A course with this slug already exists."); ;

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