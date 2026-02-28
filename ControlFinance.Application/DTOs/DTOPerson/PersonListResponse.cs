using ControlFinance.Application.DTOs.DTOTransaction;

namespace ControlFinance.Application.DTOs.DTOPerson
{
    /// Classe de resposta para a entidade "Person" em uma lista, contendo as propriedades que serão retornadas ao cliente ao solicitar uma lista de pessoas
    public class PersonListResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public List<TransactionListResponse> Transaction { get; set; }
    }
}
