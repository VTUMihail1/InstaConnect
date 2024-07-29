using InstaConnect.Messages.Data.Features.Messages.Extensions;
using InstaConnect.Messages.Data.Features.Users.Extensions;
using InstaConnect.Messages.Data.Helpers;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Data.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddMessageServices()
            .AddUserServices();

        serviceCollection
            .AddDatabaseContext<MessagesContext>(configuration);

        serviceCollection
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddUnitOfWork<MessagesContext>();

        return serviceCollection;
    }
}
