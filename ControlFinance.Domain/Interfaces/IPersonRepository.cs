using ControlFinance.Domain.Entities;

namespace ControlFinance.Domain.Interfaces
{
    // Interface para o repositório de pessoas, herda os métodos do repositório genérico IRepository<Person>
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person?> GetPersonWithTransactions(int personId);
        Task<List<Person>> GetAllWithTransactions();
    }
}
