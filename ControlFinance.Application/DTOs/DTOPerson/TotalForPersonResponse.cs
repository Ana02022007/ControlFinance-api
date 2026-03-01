
namespace ControlFinance.Application.DTOs.DTOPerson
{
    // DTO de resposta com totais consolidados por pessoa.
    public class TotalForPersonResponse
    {
        // Lista de totais individuais por pessoa.
        public List<PersonTotalItem> Persons { get; set; } = new();
        // Soma de todas as receitas das pessoas.
        public decimal GrandTotalRevenue { get; set; }
        // Soma de todas as despesas das pessoas.
        public decimal GrandTotalExpense { get; set; }
        // Resultado líquido geral (receitas - despesas).
        public decimal GrandTotal { get; set; }
    }

    // DTO que representa os totais de uma pessoa específica.
    public class PersonTotalItem
    {
        // Identificador da pessoa.
        public int Id { get; set; }
        // Nome da pessoa.
        public string Name { get; set; }
        // Total de receitas da pessoa.
        public decimal TotalRevenue { get; set; }
        // Total de despesas da pessoa.
        public decimal TotalExpense { get; set; }
        // Resultado líquido da pessoa (receitas - despesas).
        public decimal Total { get; set; }
    }
}
