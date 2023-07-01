using ConnectionPool.Core.Contracts;
using ConnectionPool.Playwright;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectionPool.StartUp;

public static class RegisterServices
{
    public static IServiceCollection AddConnectionPoolFeature(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IConnectionFactory, ConnectionFactory>();
        serviceCollection.AddSingleton<IConnectionPoolManager, ConnectionPoolManager>();
        
        return serviceCollection;
    }
}