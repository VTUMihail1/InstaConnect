using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Azure.Messaging;
using InstaConnect.Shared.Data.Extensions;
using InstaConnect.Follows.Data.Read;
using InstaConnect.Follows.Data.Read.Helpers;
using InstaConnect.Follows.Data.Read.Repositories;
using InstaConnect.Follows.Data.Read.Abstractions;

namespace InstaConnect.Follows.Data.Read.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IFollowRepository, FollowRepository>()
            .AddDatabaseContext<FollowsContext>(configuration)
            .AddUnitOfWork<FollowsContext>();

        return serviceCollection;
    }
}
