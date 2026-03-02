using ControlFinance.Application.DTOs.DTOCategory;
using ControlFinance.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControlFinance.Api.Controllers
{
    // Indica que esta classe funciona como controller de API.
    [ApiController]
    // Define a rota base: api/category.
    [Route("api/[controller]")]
    // Controller responsável por expor endpoints relacionados a categorias.
    public class CategoryController : ControllerBase
    {
        // Serviço de aplicação que concentra as regras de negócio de categorias.
        private readonly ICategoryServices _services;

        public CategoryController(ICategoryServices services)
        {
            // Injeta o serviço para ser usado pelos endpoints deste controller.
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryListResponse>>> GetAllCategory()
        {
            // Busca todas as categorias no serviço de aplicação.
            var category = await _services.GetAllCategory();
            // Retorna a lista de categorias com status 200.
            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponse>> GetByIdCategory([FromRoute] int id)
        {
            // Busca uma categoria específica pelo id informado na rota.
            var category = await _services.GetByIdCategory(id);
            // Retorna a categoria encontrada com status 200.
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryResponse>> CreateCategory([FromBody] CategoryRequest request)
        {
            // Envia os dados recebidos para criar uma nova categoria.
            return await _services.CreateCategory(request);
        }

        [HttpGet("totals")]
        public async Task<ActionResult<TotalForCategoryResponse>> ViewAllTotalsCategory()
        {
            // Consulta os totais consolidados por categoria.
            var totals = await _services.ViewAllTotalsCategory();
            // Retorna os totais por categoria com status 200.
            return Ok(totals);
        }
    }
}
