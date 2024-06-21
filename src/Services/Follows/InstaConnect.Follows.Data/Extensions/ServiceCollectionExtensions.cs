using InstaConnect.Follows.Data.Repositories;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Azure.Messaging;
using InstaConnect.Follows.Data.Abstractions;
using InstaConnect.Follows.Data.Helpers;
using InstaConnect.Shared.Data.Extensions;

namespace InstaConnect.Follows.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddScoped<IFollowRepository, FollowRepository>()
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddDatabaseContext<FollowsContext>(configuration)
            .AddUnitOfWork<FollowsContext>();

        return serviceCollection;
    }
}
