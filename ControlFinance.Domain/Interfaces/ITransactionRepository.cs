using ControlFinance.Domain.Entities;

namespace ControlFinance.Domain.Interfaces
{
    // Define operações específicas de repositório para transações.
    public interface ITransactionRepository : IRepository<Transaction>
    {
    }
}
