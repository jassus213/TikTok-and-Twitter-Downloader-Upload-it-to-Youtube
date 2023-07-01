using Microsoft.Extensions.DependencyInjection;
using User.Core.Contracts;
using User.Json;

namespace User.StartUp;

public static class RegisterServices
{
    public static IServiceCollection AddUserFeature(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IUserProvider, UserProvider>();
        serviceCollection.AddSingleton<IUserManager, UserManager>();

        return serviceCollection;
    }
}