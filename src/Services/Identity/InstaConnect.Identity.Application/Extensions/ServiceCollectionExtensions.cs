using InstaConnect.Common.Domain.Extensions;

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
