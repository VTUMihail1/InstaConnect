using InstaConnect.Identity.Presentation.Features.Users.Extensions;
using InstaConnect.Shared.Application.Extensions;
using InstaConnect.Shared.Presentation.Extensions;

namespace InstaConnect.Identity.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddUserServices(configuration);

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

        serviceCollection.AddEndpointsApiExplorer();

        serviceCollection.ConfigureApiBehaviorOptions();

        return serviceCollection;
    }
}
