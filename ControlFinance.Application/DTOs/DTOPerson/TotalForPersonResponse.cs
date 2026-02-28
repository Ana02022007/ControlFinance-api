
namespace ControlFinance.Application.DTOs.DTOPerson
{
    public class TotalForPersonResponse
    {
        public List<PersonTotalItem> Persons { get; set; } = new();
        public decimal GrandTotalRevenue { get; set; }
        public decimal GrandTotalExpense { get; set; }
        public decimal GrandTotal { get; set; }
    }

    public class PersonTotalItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal Total { get; set; }
    }
}
