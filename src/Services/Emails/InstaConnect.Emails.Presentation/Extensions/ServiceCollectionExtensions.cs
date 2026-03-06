using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Presentation.Extensions;

namespace InstaConnect.Emails.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddPresentation(IConfiguration configuration)
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
}
