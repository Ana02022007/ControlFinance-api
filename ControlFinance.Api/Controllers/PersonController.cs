using ControlFinance.Application.Services;
using ControlFinance.Application.DTOs.DTOPerson;
using Microsoft.AspNetCore.Mvc;

namespace ControlFinance.Api.Controllers
{
    // Indica que esta classe funciona como controller de API.
    [ApiController]
    // Define a rota base: api/person.
    [Route("api/[controller]")]
    // Controller responsável por expor endpoints relacionados a pessoas.
    public class PersonController : ControllerBase
    {
        // Serviço de aplicação que concentra as regras de negócio de pessoas.
        private readonly IPersonServices _services;

        public PersonController(IPersonServices services)
        {
            // Injeta o serviço para ser usado pelos endpoints deste controller.
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonListResponse>>> GetAllPerson()
        {
            // Busca todas as pessoas cadastradas no sistema.
            var person = await _services.GetAllPerson();
            // Retorna a lista de pessoas com status 200.
            return Ok(person);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonResponse>> GetByIdPerson([FromRoute] int id)
        {
            // Busca uma pessoa específica usando o id informado na rota.
            var person = await _services.GetByIdPerson(id);
            // Retorna a pessoa encontrada com status 200.
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<PersonResponse>> CreatePerson([FromBody] PersonRequest request)
        {
            // Envia os dados da requisição para criar uma nova pessoa.
            return await _services.CreatePerson(request);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonResponse>> UpdatePerson([FromRoute]int id,[FromBody] PersonRequest request)
        {
            // Atualiza os dados da pessoa identificada pelo id.
            var person = await _services.UpdatePerson(id, request);
            // Retorna os dados atualizados com status 200.
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson([FromRoute]int id)
        {
            // Remove a pessoa correspondente ao id informado.
            await _services.DeletePerson(id);
            // Retorna sucesso da operação com status 200.
            return Ok();
        }

        [HttpGet("totals")]
        public async Task<ActionResult<TotalForPersonResponse>> ViewAllTotalsPerson()
        {
            // Consulta os totais consolidados por pessoa.
            var totals = await _services.ViewAllTotalsPerson();
            // Retorna os totais por pessoa com status 200.
            return Ok(totals);
        }
    }
}