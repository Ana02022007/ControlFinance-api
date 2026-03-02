using ControlFinance.Domain.Entities;
using ControlFinance.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControlFinance.Infrastructure.Repositories
{
    // Repositório de transações com operações específicas para agregados.
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        // Recebe o contexto e repassa para o repositório genérico.
        public TransactionRepository(AppDbContext context) : base(context) { }

        // Consulta base para transação já incluindo categoria.
        protected override IQueryable<Transaction> Queryable =>
            _context.Set<Transaction>()
                    .Include(p => p.Category)
            .Include(a => a.Person);


        // Consulta de listagem para transação já incluindo categoria.
        protected override IQueryable<Transaction> QueryableList =>
            _context.Set<Transaction>()
                    .Include(p => p.Category)
              .Include(a => a.Person);

    }
}
