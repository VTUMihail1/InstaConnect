using InstaConnect.Common.Application.Features.Common.Extensions;
using InstaConnect.Common.Application.Features.Messaging.Extensions;
using InstaConnect.Common.Domain.Features.Mappers.Extensions;

namespace InstaConnect.Identity.Application.Features.Common.Extensions;

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
