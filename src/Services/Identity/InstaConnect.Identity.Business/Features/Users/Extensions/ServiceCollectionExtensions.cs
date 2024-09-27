using InstaConnect.Identity.Business.Features.Users.Abstractions;
using InstaConnect.Identity.Business.Features.Users.Helpers;
using InstaConnect.Identity.Business.Features.Users.Models.Options;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Business.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
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
