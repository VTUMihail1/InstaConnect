using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Identity.Application.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddApplication()
        {
            serviceCollection
                .AddUserServices()
                .AddUserClaimServices()
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
}
