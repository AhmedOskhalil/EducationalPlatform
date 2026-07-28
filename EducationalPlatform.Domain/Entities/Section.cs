using EducationalPlatform.Domain.Common;

namespace EducationalPlatform.Domain.Entities;

public class Section : BaseAuditableEntity
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int DisplayOrder { get; set; }

    public int CourseId { get; set; }

    public Course Course { get; set; } = null!;

    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}