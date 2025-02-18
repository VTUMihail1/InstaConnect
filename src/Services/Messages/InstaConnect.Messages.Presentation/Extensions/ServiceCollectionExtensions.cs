using InstaConnect.Messages.Presentation.Features.Messages.Extensions;
using InstaConnect.Messages.Presentation.Features.Users.Extensions;
using InstaConnect.Shared.Common.Extensions;
using InstaConnect.Shared.Presentation.Extensions;

namespace InstaConnect.Messages.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddUserServices()
            .AddMessageServices();

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
