using ControlFinance.Application.DTOs.DTOPerson;
using ControlFinance.Application.Mappers;
using ControlFinance.Domain.Entities;
using ControlFinance.Domain.Interfaces;

namespace ControlFinance.Application.Services
{
    public class PersonServices : IPersonServices
    {
        private readonly IPersonRepository _repository;
        public PersonServices(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<PersonResponse> GetByIdPerson(int id)
        {
            var person = await _repository.GetByIdAsync(id) ?? throw new Exception("Pessoa não encontrada.");
            return person.ConvertToResponse();
        }

        public async Task<List<PersonListResponse>> GetAllPerson()
        {
            var person = await _repository.GetAllAsync();
            return person.Select(p => p.ConvertToListResponse()).ToList();
        }
        public async Task<PersonResponse> CreatePerson(PersonRequest request)
        {
            Person person = request.ConvertToEntity();
            await _repository.AddAsync(person);
            return person.ConvertToResponse();
        }

        public async Task<PersonResponse> UpdatePerson(int id, PersonRequest request)
        {
            var person = await _repository.GetByIdAsync(id) ?? throw new Exception("Pessoa não encontrada.");
            request.ConvertToEntity(person);
            await _repository.UpdateAsync(person);
            return person.ConvertToResponse();
        }
        public async Task DeletePerson(int id)
        {
            var person = await _repository.GetPersonWithTransactions(id) ?? throw new Exception("Pessoa não encontrada.");
            await _repository.DeleteAsync(person);
        }
        public async Task<TotalForPersonResponse> ViewAllTotalsPerson()
        {
            var person = await _repository.GetAllWithTransactions();

            var items = person.Select(a => a.ConvertToPersonTotalItemResponse()).ToList();

            return new TotalForPersonResponse
            {
                Persons = items,
                GrandTotalRevenue = items.Sum(i => i.TotalRevenue),
                GrandTotalExpense = items.Sum(i => i.TotalExpense),
                GrandTotal = items.Sum(i => i.Total)
            };
        }

    }
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