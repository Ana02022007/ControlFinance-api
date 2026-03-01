using ControlFinance.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

// Implementa operações CRUD genéricas para qualquer entidade.
public class Repository<T> : IRepository<T> where T : class
{
    // Contexto do banco usado para persistência.
    protected readonly AppDbContext _context;
    // Conjunto de dados da entidade genérica.
    protected readonly DbSet<T> _dbSet;

    // Recebe o contexto via injeção de dependência.
    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    // Busca uma entidade pelo identificador.
    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    // Retorna todas as entidades desse tipo.
    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    // Adiciona uma nova entidade e salva as alterações.
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    // Atualiza uma entidade existente e salva as alterações.
    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    // Remove uma entidade e salva as alterações.
    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    // Exposição padrão da consulta para customizações em classes filhas.
    protected virtual IQueryable<T> Queryable => _dbSet;

    // Exposição padrão da consulta de listagem para customizações em classes filhas.
    protected virtual IQueryable<T> QueryableList => _dbSet;
}