using InstaConnect.Common.Extensions;
using InstaConnect.Common.Presentation.Extensions;
using InstaConnect.Follows.Presentation.Features.Follows.Extensions;
using InstaConnect.Follows.Presentation.Features.Users.Extensions;

namespace InstaConnect.Follows.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddFollowServices()
            .AddUserServices();

        serviceCollection
            .AddServicesWithMatchingInterfaces(PresentationReference.Assembly)
            .AddApiControllers()
            .AddMapper(PresentationReference.Assembly)
            .AddAuthorizationPolicies()
            .AddCorsPolicies(configuration)
            .AddSwagger()
            .AddRateLimiterPolicies()
            .AddExceptionHandler();

        return serviceCollection;
    }
}
