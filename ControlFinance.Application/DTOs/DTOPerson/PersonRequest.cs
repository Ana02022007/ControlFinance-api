using ControlFinance.Application.DTOs.DTOTransaction;

namespace ControlFinance.Application.DTOs.DTOPerson
{
    // DTO usado para receber os dados de criação/edição de pessoa.
    public class PersonRequest
    {
        // Nome da pessoa.
        public string Name { get; set; }
        // Data de nascimento da pessoa.
        public DateTime BirthDate { get; set; }
        // Lista de transações associadas recebidas na requisição.
        public List<TransactionRequest> Transaction { get; set; }
    }
}
