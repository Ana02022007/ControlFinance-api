using ControlFinance.Domain.Entities.Enums;

namespace ControlFinance.Application.DTOs.DTOCategory
{
    // DTO usado para listar categorias.
    public class CategoryListResponse
    {
        // Identificador único da categoria.
        public int Id { get; set; }
        // Descrição textual da categoria.
        public string Description { get; set; }
        // Finalidade da categoria (receita ou despesa).
        public CategoryPurpose Purpose { get; set; }
    }
}
