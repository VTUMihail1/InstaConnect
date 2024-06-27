using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InstaConnect.Shared.Data.Extensions;
using InstaConnect.Messages.Data.Read.Repositories;
using InstaConnect.Messages.Data.Read.Abstractions;
using InstaConnect.Messages.Data.Read.Helpers;
using InstaConnect.Shared.Data.Models.Options;

namespace InstaConnect.Messages.Data.Read.Extensions;

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
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IMessageRepository, MessageRepository>()
            .AddUnitOfWork<MessagesContext>();

        return serviceCollection;
    }
}
