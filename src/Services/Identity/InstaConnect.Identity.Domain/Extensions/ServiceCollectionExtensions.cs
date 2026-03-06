using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Domain.Features.UserClaims.Extensions;
using InstaConnect.Identity.Domain.Features.Users.Extensions;

namespace InstaConnect.Identity.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddDomain()
        {
            serviceCollection
                .AddUserServices()
                .AddUserClaimsServices()
                .AddRefreshTokenServices()
                .AddForgotPasswordTokenServices()
                .AddEmailConfirmationTokenServices();

            serviceCollection
                .AddMapper(IdentityDomainReference.Assembly, CommonDomainReference.Assembly)
                .AddServicesWithMatchingInterfaces(IdentityDomainReference.Assembly);

            return serviceCollection;
        }
    }
}
