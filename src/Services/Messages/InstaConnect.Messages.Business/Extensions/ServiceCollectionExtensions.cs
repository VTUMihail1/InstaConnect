using InstaConnect.Messages.Business.Features.Messages.Extensions;
using InstaConnect.Messages.Business.Features.Users.Extensions;
using InstaConnect.Shared.Business.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Business.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddMessageServices()
            .AddUserServices();

        serviceCollection
            .AddValidators(currentAssembly)
            .AddMediatR(currentAssembly)
            .AddMapper(currentAssembly)
            .AddMessageBroker(configuration, currentAssembly);

        return serviceCollection;
    }
}
