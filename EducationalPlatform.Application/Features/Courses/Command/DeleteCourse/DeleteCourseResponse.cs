namespace EducationalPlatform.Application.Features.Courses.Commands.DeleteCourse;

public class DeleteCourseResponse
{
    public bool Succeeded { get; set; }

    public string Message { get; set; } = string.Empty;

    public int? CourseId { get; set; }
}