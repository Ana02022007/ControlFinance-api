using Microsoft.Extensions.DependencyInjection;
using ControlFinance.Application.Services; 

namespace ControlFinance.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IPersonServices, PersonServices>();
        services.AddScoped<ICategoryServices, CategoryServices>();
        services.AddScoped<ITransactionServices, TransactionServices>();

        return services;
    }
}