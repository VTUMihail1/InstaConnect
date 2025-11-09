using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Presentation.Extensions;
using InstaConnect.Follows.Presentation.Features.Follows.Extensions;
using InstaConnect.Follows.Presentation.Features.Users.Extensions;

namespace InstaConnect.Follows.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddUserServices()
            .AddFollowServices();

        serviceCollection
            .AddServicesWithMatchingInterfaces(FollowPresentationReference.Assembly)
            .AddApiControllers()
            .AddMapper(FollowPresentationReference.Assembly)
            .AddAuthorizationPolicies()
            .AddCorsPolicies(configuration)
            .AddSwagger()
            .AddRateLimiterPolicies()
            .AddExceptionHandler();

        return serviceCollection;
    }
}
