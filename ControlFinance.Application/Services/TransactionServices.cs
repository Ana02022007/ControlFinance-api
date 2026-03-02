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
            var person = await _personRepository.GetByIdAsync(request.PersonId)
                         ?? throw new Exception("Pessoa não encontrada.");
            var category = await _categoryRepository.GetByIdAsync(request.CategoriesId)
                           ?? throw new Exception("Categoria não encontrada.");

            // 1. Validação de Valor
            if (request.Value <= 0)
                throw new Exception("O valor da transação deve ser positivo.");

            // 2. Validação de Compatibilidade Categoria vs Transação
            // Verifique se os IDs/Enums batem (Ex: Receita = 0, Despesa = 1)
            if ((int)request.Type != (int)category.Purpose)
            {
                throw new Exception("A categoria selecionada não é compatível com o tipo de transação.");
            }

            // 3. Validação de Idade
            var today = DateTime.Today;
            var age = today.Year - person.BirthDate.Year;
            if (person.BirthDate.Date > today.AddYears(-age)) age--;

            if (age < 18)
            {
                // Se for menor de 18, SÓ pode DESPESA. 
                // Se o tipo for RECEITA (0), ele barra.
                if (request.Type == TypeTransaction.RECEITA)
                {
                    throw new Exception("Menores de 18 anos só podem registrar despesas.");
                }
            }

            // Se passou por tudo, salva
            Transaction transaction = request.ConvertToEntity();
            await _repository.AddAsync(transaction);
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
