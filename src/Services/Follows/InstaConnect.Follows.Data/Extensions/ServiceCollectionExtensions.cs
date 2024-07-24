using InstaConnect.Follows.Data.Abstractions;
using InstaConnect.Follows.Data.Helpers;
using InstaConnect.Follows.Data.Repositories;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data.Extensions;
using InstaConnect.Shared.Data.Models.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddDatabaseOptions()
            .AddDatabaseContext<FollowsContext>(options =>
            {
                var databaseOptions = configuration
                    .GetSection(nameof(DatabaseOptions))
                    .Get<DatabaseOptions>()!;

                options.UseSqlServer(
                    databaseOptions.ConnectionString,
                    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
            });

        serviceCollection
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddScoped<IUserReadRepository, UserReadRepository>()
            .AddScoped<IUserWriteRepository, UserWriteRepository>()
            .AddScoped<IFollowReadRepository, FollowReadRepository>()
            .AddScoped<IFollowWriteRepository, FollowWriteRepository>()
            .AddCaching(configuration)
            .AddUnitOfWork<FollowsContext>();

        return serviceCollection;
    }
}
