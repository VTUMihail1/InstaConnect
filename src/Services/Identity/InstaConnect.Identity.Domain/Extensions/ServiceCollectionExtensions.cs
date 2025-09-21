using InstaConnect.Common.Extensions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Domain.Features.UserClaims.Extensions;
using InstaConnect.Users.Domain.Features.Users.Extensions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddUserServices()
            .AddUserClaimsServices()
            .AddRefreshTokenServices()
            .AddForgotPasswordTokenServices()
            .AddEmailConfirmationTokenServices();

        serviceCollection
            .AddMapper(IdentityDomainReference.Assembly)
            .AddServicesWithMatchingInterfaces(IdentityDomainReference.Assembly);

        return serviceCollection;
    }
}
