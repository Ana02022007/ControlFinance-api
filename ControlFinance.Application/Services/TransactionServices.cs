using Borderland.Entities.Enums;
using ControlFinance.Application.DTOs.DTOTransaction;
using ControlFinance.Application.Mappers;
using ControlFinance.Domain.Entities;
using ControlFinance.Domain.Interfaces;

namespace ControlFinance.Application.Services
{
    // Implementa as regras de negócio relacionadas a transações.
    public class TransactionServices : ITransactionServices
    {
        // Repositório principal de transações.
        private readonly ITransactionRepository _repository;
        // Repositório de pessoas usado para validações.
        private readonly IPersonRepository _personRepository;
        // Repositório de categorias usado para validações.
        private readonly ICategoryRepository _categoryRepository;

        public TransactionServices(ITransactionRepository transactionRepository, IPersonRepository personRepository, ICategoryRepository categoryRepository)
        {
            // Recebe os repositórios via injeção de dependência.
            _repository = transactionRepository;
            _personRepository = personRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<TransactionResponse> GetByIdTransaction(int id)
        {
            // Busca a transação pelo id e lança erro caso não exista.
            var transaction = await _repository.GetByIdAsync(id) ?? throw new Exception("Transação não encontrada.");
            // Converte a entidade para o formato de resposta.
            return transaction.ConvertToResponse();
        }

        public async Task<List<TransactionListResponse>> GetAllTransaction()
        {
            // Busca todas as transações cadastradas.
            var transaction = await _repository.GetAllAsync();
            // Converte cada entidade para o DTO de listagem.
            return transaction.Select(t => t.ConvertToListResponse()).ToList();
        }

        public async Task<TransactionResponse> CreateTransaction(TransactionRequest request)
        {
            // Verifica se a pessoa informada existe.
            var person = await _personRepository.GetByIdAsync(request.PersonId) ?? throw new Exception("Pessoa não encontrada.");
            // Verifica se a categoria informada existe.
            var category = await _categoryRepository.GetByIdAsync(request.CategoriesId) ?? throw new Exception("Categoria não encontrada.");

            // Calcula a idade da pessoa para aplicar regras de negócio.
            var today = DateTime.Today;
            var age = today.Year - person.BirthDate.Year;

            // Valida se o valor da transação é positivo.
            if (request.Value > 0)
            {
                // Ajusta a idade se o aniversário ainda não ocorreu no ano atual.
                if (person.BirthDate.Date > today.AddYears(-age)) age--;

                // Impede receita para menores de 18 anos.
                if (age < 18 && request.Type == TypeTransaction.RECEITA)
                {
                    throw new Exception("Menores de 18 anos só podem registrar despesas.");
                }

                // Garante compatibilidade entre tipo da transação e finalidade da categoria.
                if ((int)request.Type != (int)category.Purpose)
                {
                    throw new Exception("O tipo da transação deve ser compatível com o finalidade da categoria selecionada.");
                }
            }
            else
            {
                throw new Exception("O valor da transação deve ser positivo.");
            }

            // Converte os dados recebidos para a entidade de domínio.
            Transaction transaction = request.ConvertToEntity();

            // Persiste a nova transação no banco.
            await _repository.AddAsync(transaction);
            // Retorna os dados da transação criada.
            return transaction.ConvertToResponse();
        }
    }

    // Define o contrato de operações de serviço para transações.
    public interface ITransactionServices
    {
        Task<TransactionResponse> GetByIdTransaction(int id);
        Task<List<TransactionListResponse>> GetAllTransaction();
        Task<TransactionResponse> CreateTransaction(TransactionRequest request);
    }
}
