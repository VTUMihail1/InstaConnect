using InstaConnect.Messages.Data.Abstractions.Repositories;
using InstaConnect.Messages.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddDbContext<MessagesContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        serviceCollection
            .AddScoped<IMessageRepository, MessageRepository>();

        serviceCollection
            .AddHealthChecks()
            .AddDbContextCheck<MessagesContext>();

        return serviceCollection;
    }
}
