using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Abstractions;
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

        return serviceCollection;
    }
}
