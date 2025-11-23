using InstaConnect.Common.Application.Extensions;
using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Application.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Application.Features.Users.Extensions;

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
            .AddMapper(IdentityApplicationReference.Assembly, CommonApplicationReference.Assembly);

        return serviceCollection;
    }
}
