using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Presentation.Extensions;
using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Presentation.Features.Users.Extensions;

namespace InstaConnect.Identity.Presentation.Extensions;

internal static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddPresentation(IConfiguration configuration)
        {
            serviceCollection
                .AddUserServices()
                .AddForgotPasswordTokenServices()
                .AddEmailConfirmationTokenServices();

            serviceCollection
                .AddServicesWithMatchingInterfaces(IdentityPresentationReference.Assembly)
                .AddApiControllers()
                .AddMapper(IdentityPresentationReference.Assembly, CommonPresentationReference.Assembly)
                .AddAuthorizationPolicies()
                .AddCorsPolicies(configuration)
                .AddSwagger()
                .AddRateLimiterPolicies()
                .AddExceptionHandler();

            serviceCollection.AddEndpointsApiExplorer();

            return serviceCollection;
        }
    }
}
