using Microsoft.EntityFrameworkCore;
using ControlFinance.Domain.Entities;

public class AppDbContext : DbContext
{
    // Construtor que recebe as opções de configuração do DbContext
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    // Propriedades DbSet para cada entidade do domínio, representando as tabelas no banco de dados

    // DbSet para a entidade Person, representando a tabela de pessoas no banco de dados
    public DbSet<Person> Person { get; set; }

    // DbSet para a entidade Category, representando a tabela de categorias no banco de dados
    public DbSet<Category> Category { get; set; }

    // DbSet para a entidade Transaction, representando a tabela de transações no banco de dados
    public DbSet<Transaction> Transaction { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);
    //    // Configurações adicionais, se necessário
    //}
}