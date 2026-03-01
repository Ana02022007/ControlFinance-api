using ControlFinance.Domain.Entities;

namespace ControlFinance.Domain.Interfaces
{
    // Define operações específicas de repositório para pessoas.
    public interface IPersonRepository : IRepository<Person>
    {
        // Busca uma pessoa incluindo suas transações.
        Task<Person?> GetPersonWithTransactions(int personId);
        // Retorna todas as pessoas incluindo suas transações.
        Task<List<Person>> GetAllWithTransactions();
    }
}
