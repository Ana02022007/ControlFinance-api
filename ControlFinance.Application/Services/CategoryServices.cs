using ControlFinance.Application.DTOs.DTOCategory;
using ControlFinance.Application.Mappers;
using ControlFinance.Domain.Entities;
using ControlFinance.Domain.Interfaces;

namespace ControlFinance.Application.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _repository;
        public CategoryServices(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<CategoryResponse> GetByIdCategory(int id)
        {
            var category = await _repository.GetByIdAsync(id) ?? throw new Exception("Categoria não encontrada.");
            return category.ConvertToResponse();
        }
        public async Task<List<CategoryListResponse>> GetAllCategory()
        {
            var category = await _repository.GetAllAsync();
            return category.Select(p => p.ConvertToListResponse()).ToList();
        }
        public async Task<CategoryResponse> CreateCategory(CategoryRequest request)
        {
            Category category = request.ConvertToEntity();
            await _repository.AddAsync(category);
            return category.ConvertToResponse();
        }
        public async Task<TotalForCategoryResponse> ViewAllTotalsCategory()
        {
            var category = await _repository.GetAllWithTransactions();
            var items = category.Select(a => a.ConvertToCategoryTotalItemResponse()).ToList();
            return new TotalForCategoryResponse
            {
                Categories = items,
                GrandTotalRevenue = items.Sum(i => i.TotalRevenue),
                GrandTotalExpense = items.Sum(i => i.TotalExpense),
                GrandTotal = items.Sum(i => i.Total)
            };
        }

    }
    public interface ICategoryServices
    {
        Task<List<CategoryListResponse>> GetAllCategory();
        Task<CategoryResponse> CreateCategory(CategoryRequest request);
        Task<CategoryResponse> GetByIdCategory(int id);
        Task<TotalForCategoryResponse> ViewAllTotalsCategory();

    }
}
