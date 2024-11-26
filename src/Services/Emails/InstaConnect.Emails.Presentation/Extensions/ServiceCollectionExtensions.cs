using InstaConnect.Shared.Application.Extensions;
using InstaConnect.Shared.Presentation.Extensions;

namespace InstaConnect.Emails.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddApiControllers()
            .AddMapper(currentAssembly)
            .AddAuthorizationPolicies()
            .AddCorsPolicies(configuration)
            .AddSwagger()
            .AddRateLimiterPolicies()
            .AddVersioning()
            .AddCurrentUserContext()
            .AddExceptionHandler();

        serviceCollection.ConfigureApiBehaviorOptions();

        return serviceCollection;
    }
}
