using InstaConnect.Identity.Business.Features.Users.Abstractions;
using InstaConnect.Identity.Business.Features.Users.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Business.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IAccessTokenGenerator, AccessTokenGenerator>()
            .AddTransient<IEmailConfirmationTokenPublisher, EmailConfirmationTokenPublisher>()
            .AddTransient<IForgotPasswordTokenPublisher, ForgotPasswordTokenPublisher>()
            .AddScoped<IEmailConfirmationTokenGenerator, EmailConfirmationTokenGenerator>()
            .AddScoped<IForgotPasswordTokenGenerator, ForgotPasswordTokenGenerator>();

        return serviceCollection;
    }
}
