using InstaConnect.Follows.Presentation.Features.Follows.Extensions;
using InstaConnect.Follows.Presentation.Features.Users.Extensions;
using InstaConnect.Shared.Presentation.Extensions;

namespace InstaConnect.Follows.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddFollowServices()
            .AddUserServices();

        serviceCollection
            .AddApiControllers()
            .AddAutoMapper(currentAssembly)
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
