using Microsoft.Extensions.DependencyInjection;
using ControlFinance.Application.Services; 

namespace ControlFinance.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Registra os serviços da camada de aplicação para injeção de dependência.
        services.AddScoped<IPersonServices, PersonServices>();
        services.AddScoped<ICategoryServices, CategoryServices>();
        services.AddScoped<ITransactionServices, TransactionServices>();

        // Retorna a coleção para permitir encadeamento de chamadas.
        return services;
    }
}