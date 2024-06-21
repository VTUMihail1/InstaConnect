using InstaConnect.Shared.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Shared.Data.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection serviceCollection)
    where TContext : DbContext
    {
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>(sp => 
        new UnitOfWork(sp.GetRequiredService<TContext>()));

        return serviceCollection;
    }

    public static IServiceCollection AddDatabaseContext<TContext>(
        this IServiceCollection serviceCollection, 
        IConfiguration configuration, 
        Action<DbContextOptionsBuilder>? optionsAction = null)
    where TContext : DbContext
    {
        serviceCollection.AddDbContext<TContext>(options =>
        {
            options
              .UseSqlServer(
                  configuration.GetConnectionString("DefaultConnection"),
                  sqlServerOptions => sqlServerOptions.EnableRetryOnFailure())
              .AddInterceptors(new AuditableEntityInterceptor());

            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            optionsAction?.Invoke(options);
        });

        serviceCollection
            .AddHealthChecks()
            .AddDbContextCheck<TContext>();

        return serviceCollection;
    }
}
