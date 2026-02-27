using ControlFinance.Domain.Interfaces;

namespace ControlFinance.Application.Services
{
    // Classe abstrata genérica para serviços de CRUD (Create, Read, Update, Delete) que pode ser utilizada para diferentes tipos de entidades, solicitações e respostas, e repositórios
    public abstract class ServicesGenericCrud<T, TRequest, TResponse, TRepository>
        where T : class
        where TRepository : IRepository<T>
    {
        // Campo protegido para o repositório genérico, que será utilizado para realizar as operações de CRUD
        protected readonly TRepository _repository;

        // Construtor que recebe o repositório genérico como dependência e o atribui ao campo protegido
        public ServicesGenericCrud(TRepository repository)
        {
            _repository = repository;
        }

        // Método para inserir uma nova entidade no banco de dados, recebendo um objeto de solicitação e retornando um objeto de resposta
        public abstract Task<TResponse> InsertAsync(TRequest request);
        public abstract Task UpdateAsync(int id, TRequest request);
    }
}
