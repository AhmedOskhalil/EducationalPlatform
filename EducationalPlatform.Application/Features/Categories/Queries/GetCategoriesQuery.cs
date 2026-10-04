using MediatR;
using EducationalPlatform.Domain.Entities;

namespace EducationalPlatform.Application.Features.Categories.Queries.GetCategories;

public record GetCategoriesQuery : IRequest<IReadOnlyList<Category>>;