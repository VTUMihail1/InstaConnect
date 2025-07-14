using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Extensions;
using InstaConnect.Common.Tests.Utilities.Events;
using InstaConnect.Common.Tests.Utilities.StringVariant;

using MassTransit;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;

using WebMotions.Fake.Authentication.JwtBearer;

namespace InstaConnect.Common.Tests.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTestEventHarness(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMassTransitTestHarness();
        serviceCollection.AddScoped<IEventHarness, EventHarness>();

        return serviceCollection;
    }

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

    public static IServiceCollection AddTestJwtAuth(this IServiceCollection serviceCollection)
    {
        serviceCollection
                .AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = FakeJwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = FakeJwtBearerDefaults.AuthenticationScheme;
                })
                .AddFakeJwtBearer(opt => opt.BearerValueType = FakeJwtBearerBearerValueType.Jwt);

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
