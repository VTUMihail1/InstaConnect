using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers;
using InstaConnect.Identity.Infrastructure.Features.Users.Helpers;
using InstaConnect.Identity.Infrastructure.Features.Users.Models.Options;
using InstaConnect.Identity.Infrastructure.Features.Users.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddOptions<AdminOptions>()
            .BindConfiguration(nameof(AdminOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        serviceCollection
            .AddTransient<IUserWriteRepository, UserWriteRepository>()
            .AddTransient<IUserReadRepository, UserReadRepository>()
            .AddScoped<IPasswordHasher, PasswordHasher>();

        serviceCollection
            .AddScoped<IAccessTokenGenerator, AccessTokenGenerator>()
            .AddTransient<IEmailConfirmationTokenPublisher, EmailConfirmationTokenPublisher>()
            .AddTransient<IForgotPasswordTokenPublisher, ForgotPasswordTokenPublisher>()
            .AddScoped<IEmailConfirmationTokenGenerator, EmailConfirmationTokenGenerator>()
            .AddScoped<IForgotPasswordTokenGenerator, ForgotPasswordTokenGenerator>();

        return serviceCollection;
    }
}
