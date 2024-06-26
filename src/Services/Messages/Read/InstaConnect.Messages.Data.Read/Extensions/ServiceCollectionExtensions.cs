using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InstaConnect.Shared.Data.Extensions;
using InstaConnect.Messages.Data.Read.Repositories;
using InstaConnect.Messages.Data.Read.Abstractions;
using InstaConnect.Messages.Data.Read.Helpers;

namespace InstaConnect.Messages.Data.Read.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IMessageRepository, MessageRepository>()
            .AddDatabaseContext<MessagesContext>(configuration)
            .AddUnitOfWork<MessagesContext>();

        return serviceCollection;
    }
}
