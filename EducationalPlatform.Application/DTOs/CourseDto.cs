using EducationalPlatform.Domain.Enums;

namespace EducationalPlatform.Application.DTOs;

public class CourseDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string ShortDescription { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public CourseDifficulty Difficulty { get; set; }

    public CourseDeliveryType DeliveryType { get; set; }

    public CourseStatus Status { get; set; }

    public int CategoryId { get; set; }
}