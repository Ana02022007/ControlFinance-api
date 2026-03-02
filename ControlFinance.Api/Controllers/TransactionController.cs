using ControlFinance.Application.DTOs.DTOTransaction;
using ControlFinance.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControlFinance.Api.Controllers
{
    // Indica que esta classe funciona como controller de API.
    [ApiController]
    // Define a rota base: api/transaction.
    [Route("api/[controller]")]
    // Controller responsável por expor endpoints relacionados a transações.
    public class TransactionController : ControllerBase
    {
        // Serviço de aplicação que concentra as regras de negócio de transações.
        private readonly ITransactionServices _services;

        public TransactionController(ITransactionServices services)
        {
            // Injeta o serviço para ser usado pelos endpoints deste controller.
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<List<TransactionListResponse>>> GetAllTransaction()
        {
            // Busca todas as transações cadastradas no sistema.
            var transaction = await _services.GetAllTransaction();
            // Retorna a lista de transações com status 200.
            return Ok(transaction);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionResponse>> GetByIdTransaction([FromRoute] int id)
        {
            // Busca uma transação específica usando o id informado na rota.
            var transaction = await _services.GetByIdTransaction(id);
            // Retorna a transação encontrada com status 200.
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult<TransactionResponse>> CreateTransaction([FromBody] TransactionRequest request)
        {
            // Envia os dados recebidos para criar uma nova transação.
             return await _services.CreateTransaction(request);
        }
    }
}
