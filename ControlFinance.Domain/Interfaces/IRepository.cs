using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlFinance.Domain.Interfaces
{
    // Interface genérica para repositórios, definindo os métodos básicos de CRUD (Create, Read, Update, Delete) para entidades do domínio
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}