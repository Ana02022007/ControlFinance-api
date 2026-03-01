using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlFinance.Domain.Interfaces
{
    // Define o contrato base de CRUD para qualquer entidade de domínio.
    public interface IRepository<T> where T : class
    {
        // Busca uma entidade pelo identificador.
        Task<T?> GetByIdAsync(int id);
        // Retorna todas as entidades do tipo.
        Task<List<T>> GetAllAsync();
        // Adiciona uma nova entidade.
        Task AddAsync(T entity);
        // Atualiza uma entidade existente.
        Task UpdateAsync(T entity);
        // Remove uma entidade existente.
        Task DeleteAsync(T entity);
    }
}