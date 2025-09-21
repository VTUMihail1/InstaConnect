using InstaConnect.Common.Application.Extensions;
using InstaConnect.Common.Extensions;
using InstaConnect.EmailConfirmationTokens.Application.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.ForgotPasswordTokens.Application.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.RefreshTokens.Application.Features.RefreshTokens.Extensions;
using InstaConnect.Users.Application.Features.Users.Extensions;

namespace InstaConnect.Identity.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddUserServices()
            .AddRefreshTokenServices()
            .AddForgotPasswordTokenServices()
            .AddEmailConfirmationTokenServices();

        serviceCollection
            .AddValidators(IdentityApplicationReference.Assembly)
            .AddCQRS(IdentityApplicationReference.Assembly)
            .AddMapper(IdentityApplicationReference.Assembly);

        return serviceCollection;
    }
}
