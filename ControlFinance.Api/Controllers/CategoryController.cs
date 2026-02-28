using ControlFinance.Application.DTOs.DTOCategory;
using ControlFinance.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControlFinance.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _services;
        public CategoryController(ICategoryServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<ActionResult<List<CategoryListResponse>>> GetAllCategory()
        {
            var category = await _services.GetAllCategory();
            return Ok(category);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponse>> GetByIdCategory([FromRoute] int id)
        {
            var category = await _services.GetByIdCategory(id);
            return Ok(category);
        }
        [HttpPost]
        public async Task<ActionResult<CategoryResponse>> CreateCategory([FromBody] CategoryRequest request)
        {
            return await _services.CreateCategory(request);
        }
        [HttpGet("totals")]
        public async Task<ActionResult<TotalForCategoryResponse>> ViewAllTotalsCategory()
        {
            var totals = await _services.ViewAllTotalsCategory();
            return Ok(totals);
        }
    }
}
