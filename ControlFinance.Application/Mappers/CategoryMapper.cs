using Borderland.Entities.Enums;
using ControlFinance.Application.DTOs.DTOCategory;
using ControlFinance.Domain.Entities;

namespace ControlFinance.Application.Mappers
{
    public static class CategoryMapper
    {
        public static Category ConvertToEntity(this CategoryRequest request)
        {
            return request.ConvertToEntity(new Category());
        }
        public static Category ConvertToEntity(this CategoryRequest request, Category category)
        {
            category.Description = request.Description;
            category.Purpose = request.Purpose;
            return category;
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
        public static CategoryTotalItem ConvertToCategoryTotalItemResponse(this Category category)
        {
            var totalRevenue = category.Transactions?
                .Where(t => t.Type == TypeTransaction.RECEITA)
                .Sum(t => t.Value) ?? 0;
            var totalExpense = category.Transactions?
                .Where(t => t.Type == TypeTransaction.DESPESA)
                .Sum(t => t.Value) ?? 0;
            return new CategoryTotalItem
            {
                Id = category.Id,
                Description = category.Description,
                Purpose = category.Purpose,
                TotalRevenue = totalRevenue,
                TotalExpense = totalExpense,
                Total = totalRevenue - totalExpense
            };
        }
    }
}
