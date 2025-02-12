using InstaConnect.Messages.Presentation.Features.Messages.Extensions;
using InstaConnect.Messages.Presentation.Features.Users.Extensions;
using InstaConnect.Shared.Application.Extensions;
using InstaConnect.Shared.Presentation.Extensions;

namespace InstaConnect.Messages.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddUserServices()
            .AddMessageServices();

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
