using InstaConnect.Identity.Business.Features.Users.Abstractions;
using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Identity.Data.Features.Users.Helpers;
using InstaConnect.Identity.Data.Features.Users.Models.Options;
using InstaConnect.Identity.Data.Features.Users.Repositories;
using InstaConnect.Identity.Infrastructure.Features.Users.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Data.Features.Users.Extensions;

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
