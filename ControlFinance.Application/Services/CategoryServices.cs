using ControlFinance.Application.DTOs.DTOCategory;
using ControlFinance.Application.Mappers;
using ControlFinance.Domain.Entities;
using ControlFinance.Domain.Interfaces;

namespace ControlFinance.Application.Services
{
    // Implementa as regras de negócio relacionadas a categorias.
    public class CategoryServices : ICategoryServices
    {
        // Repositório usado para acesso aos dados de categoria.
        private readonly ICategoryRepository _repository;

        public CategoryServices(ICategoryRepository repository)
        {
            // Recebe o repositório via injeção de dependência.
            _repository = repository;
        }

        public async Task<CategoryResponse> GetByIdCategory(int id)
        {
            // Busca a categoria pelo id e lança erro caso não exista.
            var category = await _repository.GetByIdAsync(id) ?? throw new Exception("Categoria não encontrada.");
            // Converte a entidade para o formato de resposta.
            return category.ConvertToResponse();
        }

        public async Task<List<CategoryListResponse>> GetAllCategory()
        {
            // Busca todas as categorias cadastradas.
            var category = await _repository.GetAllAsync();
            // Converte cada entidade para o DTO de listagem.
            return category.Select(p => p.ConvertToListResponse()).ToList();
        }

        public async Task<CategoryResponse> CreateCategory(CategoryRequest request)
        {
            // Converte os dados recebidos para a entidade de domínio.
            Category category = request.ConvertToEntity();
            // Persiste a nova categoria no banco.
            await _repository.AddAsync(category);
            // Retorna os dados da categoria criada.
            return category.ConvertToResponse();
        }

        public async Task<TotalForCategoryResponse> ViewAllTotalsCategory()
        {
            // Busca categorias já com suas transações para cálculo de totais.
            var category = await _repository.GetAllWithTransactions();
            // Converte cada categoria em item consolidado de totalização.
            var items = category.Select(a => a.ConvertToCategoryTotalItemResponse()).ToList();

            // Retorna o consolidado geral e por categoria.
            return new TotalForCategoryResponse
            {
                Categories = items,
                GrandTotalRevenue = items.Sum(i => i.TotalRevenue),
                GrandTotalExpense = items.Sum(i => i.TotalExpense),
                GrandTotal = items.Sum(i => i.Total)
            };
        }

    }

    // Define o contrato de operações de serviço para categorias.
    public interface ICategoryServices
    {
        Task<List<CategoryListResponse>> GetAllCategory();
        Task<CategoryResponse> CreateCategory(CategoryRequest request);
        Task<CategoryResponse> GetByIdCategory(int id);
        Task<TotalForCategoryResponse> ViewAllTotalsCategory();

    }
}
