namespace EducationalPlatform.Application.Features.Courses.Commands.CreateCourse;

public class CreateCourseResponse
{
    public bool Succeeded { get; set; }

    public string Message { get; set; } = string.Empty;

    public Guid? CourseId { get; set; }
}