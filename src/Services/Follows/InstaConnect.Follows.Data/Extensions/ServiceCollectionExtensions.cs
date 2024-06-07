using InstaConnect.Follows.Data.Abstractions.Repositories;
using InstaConnect.Follows.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<FollowsContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        serviceCollection
            .AddScoped<IFollowRepository, FollowRepository>();

        serviceCollection
            .AddHealthChecks()
            .AddDbContextCheck<FollowsContext>();

        return serviceCollection;
    }
}
