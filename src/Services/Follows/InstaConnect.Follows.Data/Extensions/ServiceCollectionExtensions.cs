using InstaConnect.Follows.Data.Repositories;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Azure.Messaging;
using InstaConnect.Follows.Data.Abstractions;
using InstaConnect.Follows.Data.Helpers;

namespace InstaConnect.Follows.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddDbContext<FollowsContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                options => options.EnableRetryOnFailure()));

        serviceCollection
            .AddScoped<IUnitOfWork, UnitOfWork>(sp => new UnitOfWork(sp.GetRequiredService<FollowsContext>()))
            .AddScoped<IFollowRepository, FollowRepository>()
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>();

        serviceCollection
            .AddHealthChecks()
            .AddDbContextCheck<FollowsContext>();

        return serviceCollection;
    }
}
