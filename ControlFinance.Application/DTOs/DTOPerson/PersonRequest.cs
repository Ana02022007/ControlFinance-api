using ControlFinance.Application.DTOs.DTOTransaction;

namespace ControlFinance.Application.DTOs.DTOPerson
{
    // Classe de solicitação para a entidade "Person", contendo as propriedades que serão recebidas do cliente para realizar uma operação de CRUD (Create, Read, Update, Delete)
    public class PersonRequest
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public List<TransactionRequest> Transaction { get; set; }
    }
}
