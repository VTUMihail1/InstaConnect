using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Shared.Application.IntegrationTests.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTestDbContext<TContext>(this IServiceCollection serviceCollection, Action<DbContextOptionsBuilder>? optionsAction = null)
      where TContext : DbContext
    {
        var efCoreDescriptor = serviceCollection.SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<TContext>));

        if (efCoreDescriptor != null)
        {
            serviceCollection.Remove(efCoreDescriptor);
        }

        serviceCollection.AddDbContext<TContext>(options => optionsAction?.Invoke(options));

        return serviceCollection;
    }

    public static IServiceCollection AddTestRedisCache(this IServiceCollection serviceCollection, Action<RedisCacheOptions>? optionsAction = null!)
    {
        var descriptor = serviceCollection.SingleOrDefault(s => s.ServiceType == typeof(IDistributedCache));

        if (descriptor != null)
        {
            serviceCollection.Remove(descriptor);
        }

        serviceCollection.AddStackExchangeRedisCache(options => optionsAction?.Invoke(options));

        return serviceCollection;
    }
}
