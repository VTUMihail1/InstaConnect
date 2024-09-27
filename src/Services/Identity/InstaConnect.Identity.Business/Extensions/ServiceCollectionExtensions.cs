using InstaConnect.Identity.Business.Features.Users.Extensions;
using InstaConnect.Identity.Data;
using InstaConnect.Shared.Business.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Business.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddUserServices();

        serviceCollection
            .AddValidators(currentAssembly)
            .AddMediatR(currentAssembly)
            .AddMapper(currentAssembly)
            .AddImageHandler(configuration)
            .AddMessageBroker(configuration, currentAssembly, busConfigurator =>
                busConfigurator.AddTransactionalOutbox<IdentityContext>());

        return serviceCollection;
    }
}
