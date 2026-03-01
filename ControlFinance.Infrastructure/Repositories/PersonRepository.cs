using ControlFinance.Domain.Entities;
using ControlFinance.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControlFinance.Infrastructure.Repositories
{
    // Repositório de pessoas com operações específicas para agregados.
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        // Recebe o contexto e repassa para o repositório genérico.
        public PersonRepository(AppDbContext context) : base(context) { }

        // Consulta base para pessoa já incluindo transações.
        protected override IQueryable<Person> Queryable =>
            _context.Set<Person>()
                    .Include(p => p.Transaction);

        // Consulta de listagem para pessoa já incluindo transações.
        protected override IQueryable<Person> QueryableList =>
            _context.Set<Person>()
                    .Include(p => p.Transaction);

        public async Task<Person?> GetPersonWithTransactions(int personId)
        {
            // Busca uma pessoa específica com suas transações.
            return await _context.Set<Person>()
                .Include(p => p.Transaction)
                .FirstOrDefaultAsync(p => p.Id == personId);
        }

        public async Task<List<Person>> GetAllWithTransactions()
        {
            // Retorna todas as pessoas com suas transações.
            return await _context.Set<Person>()
                .Include(p => p.Transaction)
                .ToListAsync();
        }
    }
}