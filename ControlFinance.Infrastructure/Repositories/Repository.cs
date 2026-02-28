using ControlFinance.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

// Repositório genérico para operações CRUD, implementando a interface IRepository<T>
public class Repository<T> : IRepository<T> where T : class
{
    // Campos protegidos para o contexto do banco de dados e o DbSet<T> correspondente à entidade genérica T
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    // Construtor que recebe o AppDbContext como dependência e inicializa o DbSet<T> para a entidade genérica T
    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    // Método para obter uma entidade do banco de dados pelo seu ID
    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    // Método para obter todas as entidades do banco de dados
    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    // Método para adicionar uma nova entidade ao banco de dados
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    // Método para atualizar uma entidade existente no banco de dados
    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
    // Método para excluir uma entidade do banco de dados
    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
    // Propriedade virtual com implementação padrão
    protected virtual IQueryable<T> Queryable => _dbSet;

    // Propriedade virtual para lista (pode incluir relationships se quiser sobrescrever)
    protected virtual IQueryable<T> QueryableList => _dbSet;
}