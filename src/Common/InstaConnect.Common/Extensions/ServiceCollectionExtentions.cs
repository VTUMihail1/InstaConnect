using System.Reflection;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Helpers;

using Microsoft.Extensions.DependencyInjection;

using Scrutor;

namespace InstaConnect.Common.Extensions;
public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddMapper(this IServiceCollection serviceCollection, Assembly assembly)
    {
        serviceCollection.AddAutoMapper(assembly);

        serviceCollection.AddScoped<IInstaConnectMapper, InstaConnectMapper>();

        return serviceCollection;
    }

    public static IServiceCollection AddServicesWithMatchingInterfaces(this IServiceCollection serviceCollection, Assembly assembly)
    {
        serviceCollection
            .Scan(selector => selector
            .FromAssemblies(assembly)
            .AddClasses(false)
            .UsingRegistrationStrategy(RegistrationStrategy.Throw)
            .AsMatchingInterface()
            .WithScopedLifetime());

        return serviceCollection;
    }
}
