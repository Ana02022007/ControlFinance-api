using Microsoft.Extensions.DependencyInjection;

namespace ControlFinance.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddScoped<IPersonService, PersonService>();

        return services;
    }
}