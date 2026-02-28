using ControlFinance.Application.DTOs.DTOTransaction;
using ControlFinance.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControlFinance.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionServices _services;
        public TransactionController(ITransactionServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<ActionResult<List<TransactionListResponse>>> GetAllTransaction()
        {
            var transaction = await _services.GetAllTransaction();
            return Ok(transaction);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionResponse>> GetByIdTransaction([FromRoute] int id)
        {
            var transaction = await _services.GetByIdTransaction(id);
            return Ok(transaction);
        }
        [HttpPost]
        public async Task<ActionResult<TransactionResponse>> CreateTransaction([FromBody] TransactionRequest request)
        {
            return await _services.CreateTransaction(request);
        }
    }
}
