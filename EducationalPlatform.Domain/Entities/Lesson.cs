using EducationalPlatform.Domain.Common;

namespace EducationalPlatform.Domain.Entities;

public class Lesson : BaseAuditableEntity
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int DisplayOrder { get; set; }

    public TimeSpan Duration { get; set; }

    public bool IsPreview { get; set; }

    public int SectionId { get; set; }

    public Section Section { get; set; } = null!;
    public ICollection<LessonContent> Contents { get; set; } = new List<LessonContent>();
}