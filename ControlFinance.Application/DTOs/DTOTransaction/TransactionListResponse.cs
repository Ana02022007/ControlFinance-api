using Borderland.Entities.Enums;

namespace ControlFinance.Application.DTOs.DTOTransaction
{
    // DTO usado para listar transações.
    public class TransactionListResponse
    {
        // Identificador único da transação.
        public int Id { get; set; }
        // Descrição da transação.
        public string Description { get; set; }
        // Valor monetário da transação.
        public decimal Value { get; set; }
        // Data em que a transação ocorreu.
        public DateTime Date { get; set; }
        // Tipo da transação (receita ou despesa).
        public TypeTransaction Type { get; set; }
        // Id da pessoa associada à transação.
        public int PersonId { get; set; }
        // Id da categoria associada à transação.
        public int CategoriesId { get; set; }
    }
}
