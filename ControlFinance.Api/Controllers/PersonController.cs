using ControlFinance.Application.Services;
using ControlFinance.Application.DTOs.DTOPerson;
using Microsoft.AspNetCore.Mvc;

namespace ControlFinance.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServices _services;
        public PersonController(IPersonServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<ActionResult<List<PersonListResponse>>> GetAllPerson()
        {
            var person = await _services.GetAllPerson();
            return Ok(person);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonResponse>> GetByIdPerson([FromRoute] int id)
        {
            var person = await _services.GetByIdPerson(id);
            return Ok(person);
        }
        [HttpPost]
        public async Task<ActionResult<PersonResponse>> CreatePerson([FromBody] PersonRequest request)
        {
            return await _services.CreatePerson(request);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<PersonResponse>> UpdatePerson([FromRoute]int id,[FromBody] PersonRequest request)
        {
            var person = await _services.UpdatePerson(id, request);
            return Ok(person);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson([FromRoute]int id)
        {
            await _services.DeletePerson(id);
            return Ok();
        }
        [HttpGet("totals")]
        public async Task<ActionResult<TotalForPersonResponse>> ViewAllTotalsPerson()
        {
            var totals = await _services.ViewAllTotalsPerson();
            return Ok(totals);
        }
    }
}