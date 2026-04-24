using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Mappers.Extensions;
using InstaConnect.Common.Presentation.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Features.Controllers.Extensions;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Extensions;
using InstaConnect.Follows.Presentation.Features.Follows.Extensions;
using InstaConnect.Follows.Presentation.Features.Users.Extensions;

namespace InstaConnect.Follows.Presentation.Features.Common.Extensions;

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
