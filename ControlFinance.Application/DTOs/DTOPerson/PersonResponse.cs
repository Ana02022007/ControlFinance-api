using ControlFinance.Application.DTOs.DTOTransaction;

namespace ControlFinance.Application.DTOs.DTOPerson
{
    // Classe de resposta para a entidade "Person", contendo as propriedades que serão retornadas ao cliente após uma operação de CRUD (Create, Read, Update, Delete)
    public class PersonResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public List<TransactionResponse> Transaction { get; set; }

    }
}
