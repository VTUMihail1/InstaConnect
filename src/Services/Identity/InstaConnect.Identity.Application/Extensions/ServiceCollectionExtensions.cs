using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Application.Features.Users.Extensions;
using InstaConnect.Shared.Application.Extensions;
using InstaConnect.Shared.Common.Extensions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddUserServices()
            .AddForgotPasswordTokenServices()
            .AddEmailConfirmationTokenServices();

        serviceCollection
            .AddValidators(ApplicationReference.Assembly)
            .AddMediatR(ApplicationReference.Assembly)
            .AddMapper(ApplicationReference.Assembly);

        return serviceCollection;
    }
}
