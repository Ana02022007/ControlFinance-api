using ControlFinance.Domain.Entities;
using ControlFinance.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControlFinance.Infrastructure.Repositories
{
    // Repositório específico para a entidade Person, herda os métodos do repositório genérico Repository<Person> e implementa a interface IPersonRepository
    public class PersonRepository : Repository<Person>, IPersonRepository
    {// Construtor que recebe o AppDbContext como dependência e passa para a classe base Repository<Person>
        public PersonRepository(AppDbContext context) : base(context) { }
        // Propriedades que sobrescrevem as propriedades virtuais da classe base Repository<Person> para incluir o relacionamento com a entidade Transaction
        protected override IQueryable<Person> Queryable =>
            _context.Set<Person>()
                    .Include(p => p.Transaction);

        // Propriedade para lista que inclui o relacionamento com a entidade Transaction, permitindo obter uma lista de pessoas com suas transações associadas
        protected override IQueryable<Person> QueryableList =>
            _context.Set<Person>()
                    .Include(p => p.Transaction);

        // Método para excluir uma pessoa do banco de dados, incluindo suas transações associadas
        public void DeletePersonWithTransactions(int personId)
        {
            _context.Set<Person>().Include(p => p.Transaction)
                    .FirstOrDefault(p => p.Id == personId);
        }
    }
}