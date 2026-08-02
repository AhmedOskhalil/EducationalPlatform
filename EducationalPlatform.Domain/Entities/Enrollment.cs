using EducationalPlatform.Domain.Common;

namespace EducationalPlatform.Domain.Entities;

public class Enrollment : BaseAuditableEntity
{
    public string StudentId { get; set; } = string.Empty;

    public int CourseId { get; set; }

    public Course Course { get; set; } = null!;

    public DateTime EnrolledAt { get; set; }

    public DateTime? ExpireAt { get; set; }

    public decimal ProgressPercentage { get; set; }

    public bool IsCompleted { get; set; }

    public bool IsActive { get; set; }
}