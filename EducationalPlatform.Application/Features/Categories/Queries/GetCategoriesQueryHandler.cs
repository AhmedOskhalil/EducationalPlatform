using EducationalPlatform.Application.Interfaces;
using EducationalPlatform.Domain.Entities;
using MediatR;

namespace EducationalPlatform.Application.Features.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IReadOnlyList<Category>>
{
    private readonly ICategoryService _categoryService;

    public GetCategoriesQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IReadOnlyList<Category>> Handle(
        GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        return await _categoryService.GetAllAsync();
    }
}