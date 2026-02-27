using ControlFinance.Application.DTOs.DTOCategory;
using ControlFinance.Domain.Entities;

namespace ControlFinance.Application.Mappers
{
    public static class CategoryMapper
    {
        public static Category ConvertToEntity(this CategoryRequest request)
        {
            return new Category
            {
                Description = request.Description,
                Purpose = request.Purpose,
            };
        }
        public static CategoryResponse ConvertToResponse(this Category category)
        {
            return new CategoryResponse
            {
                Id = category.Id,
                Description = category.Description,
                Purpose = category.Purpose,
            };
        }
        public static CategoryListResponse ConvertToListResponse(this Category category)
        {
            return new CategoryListResponse
            {
                Id = category.Id,
                Description = category.Description,
                Purpose = category.Purpose,
            };
        }
    }
}
