using Microsoft.Extensions.DependencyInjection;
using RDP.Domain.Repositories;
using RDP.Infrastructure.Repositories;

namespace RDP.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ITodoRepository, InMemoryTodoRepository>();
        return services;
    }
}
