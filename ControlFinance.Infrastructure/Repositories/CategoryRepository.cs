using ControlFinance.Domain.Entities;
using ControlFinance.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControlFinance.Infrastructure.Repositories
{
    // Repositório de categorias com operações específicas para agregados.
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        // Recebe o contexto e repassa para o repositório genérico.
        public CategoryRepository(AppDbContext context) : base(context) { }

        // Consulta base para categoria.
        protected override IQueryable<Category> Queryable =>
            _context.Set<Category>();

        // Consulta base de listagem para categoria.
        protected override IQueryable<Category> QueryableList =>
            _context.Set<Category>();

        public async Task<List<Category>> GetAllWithTransactions()
        {
            // Retorna categorias já incluindo as transações relacionadas.
            return await _context.Set<Category>()
                .Include(p => p.Transactions)
                .ToListAsync();
        }
    }
}
