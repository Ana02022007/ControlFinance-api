using ControlFinance.Application.DTOs.DTOTransaction;
using ControlFinance.Domain.Entities.Enums;

namespace ControlFinance.Application.DTOs.DTOCategory
{
    // DTO usado para receber os dados de criação/edição de categoria.
    public class CategoryRequest
    {
        // Descrição textual da categoria.
        public string Description { get; set; }
        // Finalidade da categoria (receita ou despesa).
        public CategoryPurpose Purpose { get; set; }
    }
}
