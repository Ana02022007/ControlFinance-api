using ControlFinance.Application.DTOs.DTOPerson;
using ControlFinance.Application.Mappers;
using ControlFinance.Domain.Entities;
using ControlFinance.Domain.Interfaces;

namespace ControlFinance.Application.Services
{
    // Implementa as regras de negócio relacionadas a pessoas.
    public class PersonServices : IPersonServices
    {
        // Repositório usado para acesso aos dados de pessoa.
        private readonly IPersonRepository _repository;

        public PersonServices(IPersonRepository repository)
        {
            // Recebe o repositório via injeção de dependência.
            _repository = repository;
        }

        public async Task<PersonResponse> GetByIdPerson(int id)
        {
            // Busca a pessoa pelo id e lança erro caso não exista.
            var person = await _repository.GetByIdAsync(id) ?? throw new Exception("Pessoa n�o encontrada.");
            // Converte a entidade para o formato de resposta.
            return person.ConvertToResponse();
        }

        public async Task<List<PersonListResponse>> GetAllPerson()
        {
            // Busca todas as pessoas cadastradas.
            var person = await _repository.GetAllAsync();
            // Converte cada entidade para o DTO de listagem.
            return person.Select(p => p.ConvertToListResponse()).ToList();
        }

        public async Task<PersonResponse> CreatePerson(PersonRequest request)
        {
            // Converte os dados recebidos para a entidade de domínio.
            Person person = request.ConvertToEntity();
            // Persiste a nova pessoa no banco.
            await _repository.AddAsync(person);
            // Retorna os dados da pessoa criada.
            return person.ConvertToResponse();
        }

        public async Task<PersonResponse> UpdatePerson(int id, PersonRequest request)
        {
            // Busca a pessoa existente para atualização.
            var person = await _repository.GetByIdAsync(id) ?? throw new Exception("Pessoa n�o encontrada.");
            // Aplica os novos dados na entidade carregada.
            request.ConvertToEntity(person);
            // Persiste as alterações no banco.
            await _repository.UpdateAsync(person);
            // Retorna os dados atualizados.
            return person.ConvertToResponse();
        }

        public async Task DeletePerson(int id)
        {
            // Busca a pessoa com transações para remoção segura.
            var person = await _repository.GetPersonWithTransactions(id) ?? throw new Exception("Pessoa n�o encontrada.");
            // Remove a pessoa do banco.
            await _repository.DeleteAsync(person);
        }

        public async Task<TotalForPersonResponse> ViewAllTotalsPerson()
        {
            // Busca pessoas já com suas transações para cálculo de totais.
            var person = await _repository.GetAllWithTransactions();

            // Converte cada pessoa em item consolidado de totalização.
            var items = person.Select(a => a.ConvertToPersonTotalItemResponse()).ToList();

            // Retorna o consolidado geral e por pessoa.
            return new TotalForPersonResponse
            {
                Persons = items,
                GrandTotalRevenue = items.Sum(i => i.TotalRevenue),
                GrandTotalExpense = items.Sum(i => i.TotalExpense),
                GrandTotal = items.Sum(i => i.Total)
            };
        }

    }

    // Define o contrato de operações de serviço para pessoas.
    public interface IPersonServices
    {
        Task DeletePerson(int id);
        Task<List<PersonListResponse>> GetAllPerson();
        Task<PersonResponse> CreatePerson(PersonRequest request);
        Task<PersonResponse> GetByIdPerson(int id);
        Task<PersonResponse> UpdatePerson(int id, PersonRequest request);
        Task<TotalForPersonResponse> ViewAllTotalsPerson();
    }
}