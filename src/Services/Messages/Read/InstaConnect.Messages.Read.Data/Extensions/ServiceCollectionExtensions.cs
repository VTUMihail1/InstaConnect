using InstaConnect.Messages.Read.Data.Abstractions;
using InstaConnect.Messages.Read.Data.Helpers;
using InstaConnect.Messages.Read.Data.Repositories;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data.Extensions;
using InstaConnect.Shared.Data.Models.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Read.Data.Extensions;

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
            .AddCaching(configuration)
            .AddUnitOfWork<MessagesContext>();

        return serviceCollection;
    }
}
