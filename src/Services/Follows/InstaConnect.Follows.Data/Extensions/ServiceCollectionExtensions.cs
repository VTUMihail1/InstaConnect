using InstaConnect.Follows.Data.Abstractions.Repositories;
using InstaConnect.Follows.Data.Repositories;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Azure.Messaging;

namespace InstaConnect.Follows.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddDbContext<FollowsContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        
        serviceCollection
            .AddScoped<IUnitOfWork, UnitOfWork>(sp => new UnitOfWork(sp.GetRequiredService<FollowsContext>()))
            .AddScoped<IFollowRepository, FollowRepository>();

        serviceCollection
            .AddHealthChecks()
            .AddDbContextCheck<FollowsContext>();

        return serviceCollection;
    }
}
