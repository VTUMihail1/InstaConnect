using InstaConnect.Messages.Data.Repositories;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Messages.Data.Helpers;
using InstaConnect.Shared.Data.Extensions;

namespace InstaConnect.Messages.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddScoped<IMessageRepository, MessageRepository>()
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddDatabaseContext<MessagesContext>(configuration)
            .AddUnitOfWork<MessagesContext>();

        return serviceCollection;
    }
}
