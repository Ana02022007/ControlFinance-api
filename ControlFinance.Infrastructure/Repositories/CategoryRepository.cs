using ControlFinance.Domain.Entities;
using ControlFinance.Domain.Interfaces;

namespace ControlFinance.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        // Construtor que recebe o AppDbContext como dependência e passa para a classe base Repository<Transaction>
        public CategoryRepository(AppDbContext context) : base(context) { }

        protected override IQueryable<Category> Queryable =>
            _context.Set<Category>();

        protected override IQueryable<Category> QueryableList =>
            _context.Set<Category>();
    }
}
