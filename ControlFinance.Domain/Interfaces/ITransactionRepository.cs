using ControlFinance.Domain.Entities;

namespace ControlFinance.Domain.Interfaces
{
    // Interface para o repositório de transações, herda os métodos do repositório genérico IRepository<Transaction>
    public interface ITransactionRepository : IRepository<Transaction>
    {
    }
}
