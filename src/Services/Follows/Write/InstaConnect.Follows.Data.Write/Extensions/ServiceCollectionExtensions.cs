using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Azure.Messaging;
using InstaConnect.Shared.Data.Extensions;
using InstaConnect.Follows.Data.Write.Repositories;
using InstaConnect.Follows.Data.Write.Helpers;
using InstaConnect.Follows.Data.Write.Abstractions;
using InstaConnect.Shared.Data.Models.Options;

namespace InstaConnect.Follows.Data.Write.Extensions;

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
            .AddScoped<IFollowRepository, FollowRepository>()
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddUnitOfWork<FollowsContext>();

        return serviceCollection;
    }
}
