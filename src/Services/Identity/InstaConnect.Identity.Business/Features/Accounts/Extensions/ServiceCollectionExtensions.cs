using InstaConnect.Identity.Business.Features.Accounts.Abstractions;
using InstaConnect.Identity.Business.Features.Accounts.Helpers;
using InstaConnect.Identity.Business.Features.Accounts.Models.Options;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Business.Features.Accounts.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddAccountServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddOptions<GatewayOptions>()
            .BindConfiguration(nameof(GatewayOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        serviceCollection
            .AddScoped<IAccessTokenGenerator, AccessTokenGenerator>()
            .AddScoped<IEmailConfirmationTokenPublisher, EmailConfirmationTokenPublisher>()
            .AddScoped<IForgotPasswordTokenPublisher, ForgotPasswordTokenPublisher>();

        return serviceCollection;
    }
}
