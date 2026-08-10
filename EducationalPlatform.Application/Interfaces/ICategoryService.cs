using EducationalPlatform.Domain.Entities;

namespace EducationalPlatform.Application.Interfaces;

public interface ICategoryService
{
    Task<IReadOnlyList<Category>> GetAllAsync();
}