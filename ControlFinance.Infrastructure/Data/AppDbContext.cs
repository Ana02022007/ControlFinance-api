using Microsoft.EntityFrameworkCore;
using ControlFinance.Domain.Entities;

// Contexto principal do Entity Framework para acesso ao banco da aplicação.
public class AppDbContext : DbContext
{
    // Recebe as opções de configuração do contexto via injeção de dependência.
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Representa a tabela de pessoas no banco.
    public DbSet<Person> Person { get; set; }

    // Representa a tabela de categorias no banco.
    public DbSet<Category> Category { get; set; }

    // Representa a tabela de transações no banco.
    public DbSet<Transaction> Transaction { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);
    //    // Configura��es adicionais, se necess�rio
    //}
}