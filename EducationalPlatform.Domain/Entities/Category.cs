using EducationalPlatform.Domain.Common;

namespace EducationalPlatform.Domain.Entities;

public class Category : BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? ThumbnailUrl { get; set; }
    public bool IsActive { get; set; } = true;
}
