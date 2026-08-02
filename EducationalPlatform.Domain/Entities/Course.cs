using EducationalPlatform.Domain.Common;
using EducationalPlatform.Domain.Enums;
using static System.Collections.Specialized.BitVector32;

namespace EducationalPlatform.Domain.Entities;

public class Course : BaseAuditableEntity
{
    public string Title { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string ShortDescription { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string? ThumbnailUrl { get; set; }

    public decimal Price { get; set; }

    public TimeSpan? Duration { get; set; }

    public CourseDifficulty Difficulty { get; set; }

    public CourseDeliveryType DeliveryType { get; set; }

    public CourseStatus Status { get; set; } = CourseStatus.Draft;
    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;

    public ICollection<CourseInstructor> CourseInstructors { get; set; } = new List<CourseInstructor>();

    public ICollection<Section> Sections { get; set; } = new List<Section>();

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();  
}