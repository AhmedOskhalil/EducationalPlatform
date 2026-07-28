using EducationalPlatform.Domain.Common;
using EducationalPlatform.Domain.Enums;

namespace EducationalPlatform.Domain.Entities;

public class LessonContent : BaseAuditableEntity
{
    public int LessonId { get; set; }

    public Lesson Lesson { get; set; } = null!;

    public LessonContentType ContentType { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public long? FileSize { get; set; }

    public TimeSpan? Duration { get; set; }

    public bool IsDownloadable { get; set; }

    public int DisplayOrder { get; set; }
}