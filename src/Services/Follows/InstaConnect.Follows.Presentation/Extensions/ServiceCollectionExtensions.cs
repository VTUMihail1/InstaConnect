using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Presentation.Extensions;
using InstaConnect.Follows.Presentation.Features.Follows.Extensions;
using InstaConnect.Follows.Presentation.Features.Users.Extensions;

namespace InstaConnect.Follows.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddPresentation(IConfiguration configuration)
        {
            serviceCollection
                .AddUserServices()
                .AddFollowServices();

            serviceCollection
                .AddServicesWithMatchingInterfaces(FollowsPresentationReference.Assembly)
                .AddApiControllers()
                .AddMapper(FollowsPresentationReference.Assembly, CommonPresentationReference.Assembly)
                .AddAuthorizationPolicies()
                .AddCorsPolicies(configuration)
                .AddRateLimiterPolicies()
                .AddExceptionHandler();

            return serviceCollection;
        }
    }
}
