
using ControlFinance.Domain.Entities.Enums;

namespace ControlFinance.Application.DTOs.DTOCategory
{
    // DTO de resposta com totais consolidados por categoria.
    public class TotalForCategoryResponse
    {
        // Lista de totais individuais por categoria.
        public List<CategoryTotalItem> Categories { get; set; } = new();
        // Soma de todas as receitas das categorias.
        public decimal GrandTotalRevenue { get; set; }
        // Soma de todas as despesas das categorias.
        public decimal GrandTotalExpense { get; set; }
        // Resultado líquido geral (receitas - despesas).
        public decimal GrandTotal { get; set; }
    }

    // DTO que representa os totais de uma categoria específica.
    public class CategoryTotalItem
    {
        // Identificador da categoria.
        public int Id { get; set; }
        // Descrição da categoria.
        public string Description { get; set; }
        // Total de receitas vinculadas à categoria.
        public decimal TotalRevenue { get; set; }
        // Total de despesas vinculadas à categoria.
        public decimal TotalExpense { get; set; }
        // Resultado líquido da categoria (receitas - despesas).
        public decimal Total { get; set; }
        // Finalidade da categoria.
        public CategoryPurpose Purpose { get; set; }
    }
}
