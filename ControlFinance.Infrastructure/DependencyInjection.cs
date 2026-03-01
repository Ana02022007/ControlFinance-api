using Microsoft.Extensions.DependencyInjection;
using ControlFinance.Domain.Interfaces;
using ControlFinance.Infrastructure.Repositories;

namespace ControlFinance.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Registra os repositórios da camada de infraestrutura.
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        // Retorna a coleção para permitir encadeamento de chamadas.
        return services;
    }
}