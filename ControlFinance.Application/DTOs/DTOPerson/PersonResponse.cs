using ControlFinance.Application.DTOs.DTOTransaction;

namespace ControlFinance.Application.DTOs.DTOPerson
{
    // DTO retornado para representar uma pessoa completa.
    public class PersonResponse
    {
        // Identificador único da pessoa.
        public int Id { get; set; }
        // Nome da pessoa.
        public string Name { get; set; }
        // Data de nascimento da pessoa.
        public DateTime BirthDate { get; set; }
        // Lista de transações da pessoa na resposta detalhada.
        public List<TransactionResponse> Transaction { get; set; }

    }
}
