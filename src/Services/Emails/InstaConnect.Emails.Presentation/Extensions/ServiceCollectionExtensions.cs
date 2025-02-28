using InstaConnect.Common.Extensions;
using InstaConnect.Common.Presentation.Extensions;

namespace InstaConnect.Emails.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
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
