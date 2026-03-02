using ControlFinance.Domain.Entities;

namespace ControlFinance.Domain.Interfaces
{
    // Define operações específicas de repositório para categorias.
    public interface ICategoryRepository : IRepository<Category>
    {
        // Retorna todas as categorias incluindo suas transações.
        Task<List<Category>> GetAllWithTransactions();

    }
}
