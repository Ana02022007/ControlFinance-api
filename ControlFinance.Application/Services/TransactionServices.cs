using Borderland.Entities.Enums;
using ControlFinance.Application.DTOs.DTOTransaction;
using ControlFinance.Application.Mappers;
using ControlFinance.Domain.Entities;
using ControlFinance.Domain.Interfaces;

namespace ControlFinance.Application.Services
{
    public class TransactionServices : ITransactionServices
    {
        private readonly ITransactionRepository _repository;
        private readonly IPersonRepository _personRepository;
        private readonly ICategoryRepository _categoryRepository;
        public TransactionServices(ITransactionRepository transactionRepository, IPersonRepository personRepository, ICategoryRepository categoryRepository)
        {
            _repository = transactionRepository;
            _personRepository = personRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<TransactionResponse> GetByIdTransaction(int id)
        {
            var transaction = await _repository.GetByIdAsync(id) ?? throw new Exception("Transação não encontrada.");
            return transaction.ConvertToResponse();
        }

        public async Task<List<TransactionListResponse>> GetAllTransaction()
        {
            var transaction = await _repository.GetAllAsync();
            return transaction.Select(t => t.ConvertToListResponse()).ToList();
        }
        public async Task<TransactionResponse> CreateTransaction(TransactionRequest request)
        {
            var person = await _personRepository.GetByIdAsync(request.PersonId) ?? throw new Exception("Pessoa não encontrada.");
            var category = await _categoryRepository.GetByIdAsync(request.CategoriesId) ?? throw new Exception("Categoria não encontrada.");

            var today = DateTime.Today;
            var age = today.Year - person.BirthDate.Year;

            if (request.Value > 0)
            {
                if (person.BirthDate.Date > today.AddYears(-age)) age--;

                if (age < 18 && request.Type == TypeTransaction.RECEITA)
                {
                    throw new Exception("Menores de 18 anos só podem registrar despesas.");
                }

                if ((int)request.Type != (int)category.Purpose)
                {
                    throw new Exception("O tipo da transação deve ser compatível com o finalidade da categoria selecionada.");
                }
            }
            else
            {
                throw new Exception("O valor da transação deve ser positivo.");
            }
            Transaction transaction = request.ConvertToEntity();

            await _repository.AddAsync(transaction);
            return transaction.ConvertToResponse();
        }
    }
    public interface ITransactionServices
    {
        Task<TransactionResponse> GetByIdTransaction(int id);
        Task<List<TransactionListResponse>> GetAllTransaction();
        Task<TransactionResponse> CreateTransaction(TransactionRequest request);
    }
}
