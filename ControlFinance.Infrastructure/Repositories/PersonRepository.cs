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

        // Método para buscar uma pessoa do banco de dados, incluindo suas transações associadas
        public async Task<Person?> GetPersonWithTransactions(int personId)
        {
            return await _context.Set<Person>()
                .Include(p => p.Transaction)
                .FirstOrDefaultAsync(p => p.Id == personId);
        }
        public async Task<List<Person>> GetAllWithTransactions()
        {
            return await _context.Set<Person>()
                .Include(p => p.Transaction)
                .ToListAsync();
        }
    }
}