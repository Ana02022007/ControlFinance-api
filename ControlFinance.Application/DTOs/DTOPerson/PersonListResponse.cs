using ControlFinance.Application.DTOs.DTOTransaction;

namespace ControlFinance.Application.DTOs.DTOPerson
{
    // DTO usado para listar pessoas.
    public class PersonListResponse
    {
        // Identificador único da pessoa.
        public int Id { get; set; }
        // Nome da pessoa.
        public string Name { get; set; }
        // Data de nascimento da pessoa.
        public DateTime BirthDate { get; set; }
        // Lista resumida de transações relacionadas à pessoa.
        public List<TransactionListResponse> Transaction { get; set; }
    }
}
