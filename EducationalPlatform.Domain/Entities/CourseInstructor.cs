using EducationalPlatform.Domain.Common;

namespace EducationalPlatform.Domain.Entities;

public class CourseInstructor : BaseEntity
{
    public int CourseId { get; set; }

    public Course Course { get; set; } = null!;

    public string InstructorId { get; set; } = string.Empty;

    public bool IsPrimaryInstructor { get; set; }
}