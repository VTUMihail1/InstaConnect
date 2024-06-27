using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data.Models.Options;
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
        Action<DbContextOptionsBuilder>? optionsAction = null)
    where TContext : DbContext
    {
        serviceCollection.AddDbContext<TContext>(options =>
        {
            options.AddInterceptors(new AuditableEntityInterceptor());

            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            optionsAction?.Invoke(options);
        });

        serviceCollection
            .AddHealthChecks()
            .AddDbContextCheck<TContext>();

        return serviceCollection;
    }

    public static IServiceCollection AddDatabaseOptions(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddOptions<DatabaseOptions>()
            .BindConfiguration(nameof(DatabaseOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return serviceCollection;
    }
}
