using ControlFinance.Domain.Entities.Enums;

namespace ControlFinance.Application.DTOs.DTOCategory
{
    public class CategoryRequest
    {
        public string Description { get; set; }
        public CategoryPurpose Purpose { get; set; }
    }
}
