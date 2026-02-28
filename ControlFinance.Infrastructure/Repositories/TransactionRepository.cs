using ControlFinance.Domain.Entities;
using ControlFinance.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControlFinance.Infrastructure.Repositories
{
    // Repositório específico para a entidade Transaction, herda os métodos do repositório genérico Repository<Transaction> e implementa a interface ITransactionRepository
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        // Construtor que recebe o AppDbContext como dependência e passa para a classe base Repository<Transaction>
        public TransactionRepository(AppDbContext context) : base(context) { }
        // Propriedades que sobrescrevem as propriedades virtuais da classe base Repository<Transaction> para incluir o relacionamento com a entidade Category
        protected override IQueryable<Transaction> Queryable =>
            _context.Set<Transaction>()
                    .Include(p => p.Category);
        //Propriedade para lista que inclui o relacionamento com a entidade Category, permitindo obter uma lista de transações com suas categorias associadas
        protected override IQueryable<Transaction> QueryableList =>
            _context.Set<Transaction>()
                    .Include(p => p.Category);
   
    }
}
