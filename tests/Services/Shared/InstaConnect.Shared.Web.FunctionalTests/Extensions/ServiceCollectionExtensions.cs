using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebMotions.Fake.Authentication.JwtBearer;

namespace InstaConnect.Shared.Web.FunctionalTests.Extensions;

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
}
