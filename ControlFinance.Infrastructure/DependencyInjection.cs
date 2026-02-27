using Microsoft.Extensions.DependencyInjection;
using ControlFinance.Domain.Interfaces;
using ControlFinance.Infrastructure.Repositories;

namespace ControlFinance.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}