using EducationalPlatform.Application.Interfaces;
using EducationalPlatform.Domain.Entities;

namespace EducationalPlatform.Infrastructure.Services;

public class CategoryService : ICategoryService
{
    private readonly IRepository<Category> _categoryRepository;

    public CategoryService(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IReadOnlyList<Category>> GetAllAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }
}