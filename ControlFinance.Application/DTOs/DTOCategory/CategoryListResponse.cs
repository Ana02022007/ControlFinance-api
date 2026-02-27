using ControlFinance.Domain.Entities.Enums;

namespace ControlFinance.Application.DTOs.DTOCategory
{
    public class CategoryListResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public CategoryPurpose Purpose { get; set; }
    }
}
