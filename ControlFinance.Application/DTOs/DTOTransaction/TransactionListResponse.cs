using Borderland.Entities.Enums;

namespace ControlFinance.Application.DTOs.DTOTransaction
{
    public class TransactionListResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public TypeTransaction Type { get; set; }
        public int PersonId { get; set; }
        public int CategoriesId { get; set; }
    }
}
