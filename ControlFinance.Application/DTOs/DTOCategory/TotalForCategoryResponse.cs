
using ControlFinance.Domain.Entities.Enums;

namespace ControlFinance.Application.DTOs.DTOCategory
{
    public class TotalForCategoryResponse
    {
        public List<CategoryTotalItem> Categories { get; set; } = new();
        public decimal GrandTotalRevenue { get; set; }
        public decimal GrandTotalExpense { get; set; }
        public decimal GrandTotal { get; set; }
    }
    public class CategoryTotalItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal Total { get; set; }
        public CategoryPurpose Purpose { get; set; }
    }
}
