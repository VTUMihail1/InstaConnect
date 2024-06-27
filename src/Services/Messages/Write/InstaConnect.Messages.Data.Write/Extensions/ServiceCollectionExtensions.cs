using InstaConnect.Messages.Data.Repositories;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Messages.Data.Helpers;
using InstaConnect.Shared.Data.Extensions;
using InstaConnect.Shared.Data.Models.Options;

namespace InstaConnect.Messages.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddDatabaseOptions()
            .AddDatabaseContext<MessagesContext>(options =>
            {
                var databaseOptions = configuration
                    .GetSection(nameof(DatabaseOptions))
                    .Get<DatabaseOptions>()!;

                options.UseSqlServer(
                    databaseOptions.ConnectionString,
                    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
            });

        serviceCollection
            .AddScoped<IMessageRepository, MessageRepository>()
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddUnitOfWork<MessagesContext>();

        return serviceCollection;
    }
}
